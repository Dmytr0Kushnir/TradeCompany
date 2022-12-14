using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MaterialSkin.Controls;
using TradingCompany.BusinessLogic.Interfaces;
using TradingCompanyDataTransfer;

namespace TradingCompany.App
{
    public partial class MainForm : MaterialForm
    {
        private readonly int _id = Program.Id;
        private List<ProductDTO> _buyList = new List<ProductDTO>();
        private UserDTO _user;
        private readonly ITraderManager _managerT;
        private readonly IProductManager _managerP;
        public MainForm(ITraderManager managerT, IProductManager managerP)
        {
            _managerT = managerT;
            _managerP = managerP;
            _user = _managerT.GetUserById(_id);
            InitializeComponent();
        }



        private void button3_Click(object sender, EventArgs e)
        {
            Catalog catalog = new Catalog(_managerT,_managerP,_user);
            var res = catalog.ShowDialog();
            if (DialogResult.OK == res || DialogResult.Cancel == res)
            {
                Refresh(catalog);
            }
        }
        void Refresh(Catalog catalog)
        {
            int totalSum = 0;
            label3.Text = "Total : ";
            _buyList.AddRange(catalog.GetBuyedProducts());
            dataGridView1.Rows.Clear();
            foreach (var p in _buyList)
            {

                totalSum += p.Price;

                dataGridView1.Rows.Add(p.Id, p.Name, p.Price, p.TimeOfAdd);
            }
            label3.Text += totalSum.ToString();


        }
        private void button4_Click(object sender, EventArgs e)
        {
            string seachText = textBox1.Text;
            Catalog catalog = new Catalog(_managerT, _managerP, _user);
            catalog.SearchString = seachText;
            var res = catalog.ShowDialog();
            if (DialogResult.OK == res || DialogResult.Cancel == res)
            {
                Refresh(catalog);   
            }


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
