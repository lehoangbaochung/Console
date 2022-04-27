using FruitStoreManager.Models;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FruitStoreManager.Functions
{
    internal class Remove
    {
        public static void Item(DataGridView dataGridView)
        {
            // lấy số lượng của item trong giỏ
            var count = List.Cart.Find(s => s.ProductID == dataGridView.CurrentRow.Cells["ID"].Value).Count;
            // xóa item trong giỏ theo ID
            List.Cart.Remove(List.Cart.Find(s => s.ProductID.ToString() == dataGridView.CurrentRow.Cells["ID"].Value.ToString()));
            // thêm lại số item vào trong kho
            BindingList.Product.Where(s => s.ID.ToString() == dataGridView.CurrentRow.Cells["ID"].Value.ToString()).ToList()
                .ForEach(s => s.Quantity = (decimal)s.Quantity + (decimal)count);
            // hiển thị lại số lượng lên bảng
            dataGridView.DataSource = BindingList.Product;
        }

        public static void Account(DataGridView dataGridView)
        {
            var oldData = File.ReadAllText(Execute.GetFilePath("account"));

            var index = List.Account.FindIndex(s => s.ID == dataGridView.CurrentRow.Cells["ID"]);

            dynamic jsonObj = JsonConvert.DeserializeObject(oldData);
            jsonObj["account"][index]["ID"] = null;

            string newData = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
            File.WriteAllText(Execute.GetFilePath("account"), newData);
        }

        public static void Product(DataGridView dataGridView)
        {
            var oldData = File.ReadAllText(Execute.GetFilePath("product"));

            var index = List.Product.FindIndex(s => s.ID == dataGridView.CurrentRow.Cells["ID"]);

            dynamic jsonObj = JsonConvert.DeserializeObject(oldData);
            jsonObj["product"][index]["ID"] = null;

            string newData = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
            File.WriteAllText(Execute.GetFilePath("product"), newData);
        }
    }
}
