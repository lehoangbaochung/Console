using System.Windows.Forms;

namespace FruitStoreManager.Models
{
    class MainElement
    {
        public Form Form { get; set; }
        public TextBox TextBox { get; set; }
        public ComboBox ComboBox { get; set; }
        public TabControl TabControl { get; set; }
        public NumericUpDown NumericUpDown { get; set; }
        public DataGridView DataGridView { get; set; }
        public RichTextBox RichTextBox { get; set; }
        public Button ButtonSearch { get; set; }
        public Button ButtonLogout { get; set; }
        public Button ButtonAdd { get; set; }
        public Button ButtonEdit { get; set; }
        public Button ButtonDelete { get; set; }
        public Button ButtonMore { get; set; }
    }

    class LoginElement
    {
        public TextBox Username { get; set; }
        public TextBox Password { get; set; }
        public Button ButtonLogin { get; set; }
        public Button ButtonQuit { get; set; }
    }
}
