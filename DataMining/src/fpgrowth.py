import csv
import os
from tqdm import tqdm


def load_data(path):
	ans = []
	with open(path, "r", encoding='utf-8') as f:
		reader = csv.reader(f)
		for row in reader:
			row = list(set(row))
			row.sort()
			ans.append(row)
	return ans[1:]


def save_rule(rule, path):
	with open(path, "w", encoding='utf-8') as f:
		f.write("index\tconfidence\trules\n")
		index = 1
		for item in rule:
			s = "{:<4d}\t{:.3f}\t{}=>{}\n".format(
				index, item[2], str(list(item[0])), str(list(item[1])))
			index += 1
			f.write(s)
		f.close()
	print("Result saved at {}".format(path))


class Node:
	def __init__(self, node_name, count, parentNode):
		self.name = node_name
		self.count = count
		self.nodeLink = None
		self.parent = parentNode
		self.children = {}


class Fp_growth():
	def update_header(self, node, targetNode):
		while node.nodeLink != None:
			node = node.nodeLink
		node.nodeLink = targetNode

	def update_fptree(self, items, node, headerTable):
		if items[0] in node.children:
			node.children[items[0]].count += 1
		else:
			node.children[items[0]] = Node(items[0], 1, node)
			if headerTable[items[0]][1] == None:
				headerTable[items[0]][1] = node.children[items[0]]
			else:
				self.update_header(headerTable[items[0]][1], node.children[items[0]])

		if len(items) > 1:
			self.update_fptree(items[1:], node.children[items[0]], headerTable)

	def create_fptree(self, data_set, min_support, flag=False):
		item_count = {}
		for t in data_set:
			for item in t:
				if item not in item_count:
					item_count[item] = 1
				else:
					item_count[item] += 1
		headerTable = {}
		for k in item_count:
			if item_count[k] >= min_support:
				headerTable[k] = item_count[k]

		freqItemSet = set(headerTable.keys())
		if len(freqItemSet) == 0:
			return None, None
		for k in headerTable:
			headerTable[k] = [headerTable[k], None]
		tree_header = Node('head node', 1, None)
		if flag:
			ite = tqdm(data_set)
		else:
			ite = data_set
		for t in ite:
			localD = {}
			for item in t:
				if item in freqItemSet:
					localD[item] = headerTable[item][0]
			if len(localD) > 0:
				order_item = [v[0] for v in sorted(localD.items(), key=lambda x:x[1], reverse=True)]
				self.update_fptree(order_item, tree_header, headerTable)
		return tree_header, headerTable

	def find_path(self, node, nodepath):
		if node.parent != None:
			nodepath.append(node.parent.name)
			self.find_path(node.parent, nodepath)

	def find_cond_pattern_base(self, node_name, headerTable):
		treeNode = headerTable[node_name][1]
		cond_pat_base = {}
		while treeNode != None:
			nodepath = []
			self.find_path(treeNode, nodepath)
			if len(nodepath) > 1:
				cond_pat_base[frozenset(nodepath[:-1])] = treeNode.count
			treeNode = treeNode.nodeLink
		return cond_pat_base

	def create_cond_fptree(self, headerTable, min_support, temp, freq_items, support_data):
		freqs = [v[0] for v in sorted(headerTable.items(), key=lambda p:p[1][0])]
		for freq in freqs:
			freq_set = temp.copy()
			freq_set.add(freq)
			freq_items.add(frozenset(freq_set))
			if frozenset(freq_set) not in support_data:
				support_data[frozenset(freq_set)] = headerTable[freq][0]
			else:
				support_data[frozenset(freq_set)] += headerTable[freq][0]

			cond_pat_base = self.find_cond_pattern_base(freq, headerTable)
			cond_pat_dataset = []
			for item in cond_pat_base:
				item_temp = list(item)
				item_temp.sort()
				for _ in range(cond_pat_base[item]):
					cond_pat_dataset.append(item_temp)

			_, cur_headtable = self.create_fptree(cond_pat_dataset, min_support)
			if cur_headtable != None:
				self.create_cond_fptree(cur_headtable, min_support,
				                        freq_set, freq_items, support_data)

	def generate_L(self, data_set, min_support):
		freqItemSet = set()
		support_data = {}
		_, headerTable = self.create_fptree(data_set, min_support, flag=True)
		self.create_cond_fptree(headerTable, min_support,
		                        set(), freqItemSet, support_data)

		max_l = 0
		for i in freqItemSet:
			if len(i) > max_l:
				max_l = len(i)
		L = [set() for _ in range(max_l)]
		for i in freqItemSet:
			L[len(i)-1].add(i)
		for i in range(len(L)):
			print("The frequent of item {}: {}".format(i+1, len(L[i])))
		return L, support_data

	def generate_R(self, data_set, min_support, min_conf):
		L, support_data = self.generate_L(data_set, min_support)
		rule_list = []
		sub_set_list = []
		for i in range(0, len(L)):
			for freq_set in L[i]:
				for sub_set in sub_set_list:
					if sub_set.issubset(freq_set) and freq_set-sub_set in support_data:
						conf = support_data[freq_set] / support_data[freq_set - sub_set]
						big_rule = (freq_set - sub_set, sub_set, conf)
						if conf >= min_conf and big_rule not in rule_list:
							rule_list.append(big_rule)
				sub_set_list.append(freq_set)
		rule_list = sorted(rule_list, key=lambda x: (x[2]), reverse=True)
		return rule_list


current_path = os.getcwd()
log_path = current_path + "/DataMining/log/"
if not os.path.exists(log_path):
	os.mkdir(log_path)

file_names = ["score_revised"]
for file_name in file_names:
    file_path = current_path + "/DataMining/data/" + file_name + ".csv"
    save_path = log_path + file_name + "_fpgrowth.txt"
    print(f"Executing with '{file_name}' dataset...")

    fpgrowth = Fp_growth()
    data = load_data(file_path)
    rule_list = fpgrowth.generate_R(data, min_support=10, min_conf=.7)
    save_rule(rule_list, save_path)
