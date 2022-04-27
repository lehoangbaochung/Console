using FruitStoreManager.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FruitStoreManager.Functions
{
    internal class Edit
    {
        public static void Quantity()
        {
            var oldData = File.ReadAllText(Execute.GetFilePath("product")).Trim();

            dynamic jsonObj = JsonConvert.DeserializeObject(oldData);

            foreach (var item in List.Cart)
            {
                jsonObj["product"][Convert.ToInt32(item.ProductID)]["Quantity"] -= item.Count;
            }

            string newData = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
            File.WriteAllText(Execute.GetFilePath("product"), newData);
        }

        public static void Cart(DataGridView dataGridView, NumericUpDown numericUpDown)
        {
            // lấy số lượng của item trong giỏ
            var count = List.Cart.Find(s => s.ProductID == dataGridView.CurrentRow.Cells["ID"].Value).Count;
            // sửa lại số lượng theo đúng yêu cầu
            List.Cart.Where(s => s.ProductID == dataGridView.CurrentRow.Cells["ID"].Value).ToList().ForEach(s => s.Count = (double)numericUpDown.Value);
            // sửa lại số lượng item trong kho
            BindingList.Product.Where(s => s.ID.ToString() == dataGridView.CurrentRow.Cells["ID"].Value.ToString()).ToList()
                .ForEach(s => s.Quantity = double.Parse(s.Quantity.ToString()) + double.Parse(count.ToString()) - double.Parse(numericUpDown.Value.ToString()));
            // hiển thị lại số lượng lên bảng
            dataGridView.DataSource = BindingList.Product;
        }

        public static void Customer(DataGridView dataGridView, string fileName)
        {
            var index = BindingList.Customer.ToList().FindIndex(s => s.Name == dataGridView.CurrentRow.Cells["Name"]);

            var oldData = File.ReadAllText(Execute.GetFilePath(fileName)).Trim();

            dynamic jsonObj = JsonConvert.DeserializeObject(oldData);
            jsonObj[fileName][index][dataGridView.CurrentCell.OwningColumn.Name] = dataGridView.CurrentCell.Value?.ToString();

            string newData = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
            File.WriteAllText(Execute.GetFilePath(fileName), newData);
        }

        public static void Data(DataGridView dataGridView, string fileName)
        {
            var oldData = File.ReadAllText(Execute.GetFilePath(fileName)).Trim();

            dynamic jsonObj = JsonConvert.DeserializeObject(oldData);
            jsonObj[fileName][dataGridView.CurrentRow.Index][dataGridView.CurrentCell.OwningColumn.Name] = dataGridView.CurrentCell.Value?.ToString();

            string newData = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
            File.WriteAllText(Execute.GetFilePath(fileName), newData);
        }
    }
}
