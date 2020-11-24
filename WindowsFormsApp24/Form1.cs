using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp24
{
    public partial class Form1 : Form
    {
        DefectationEntities db;
        public Form1()
        {
            
            InitializeComponent();
            db = new DefectationEntities();
            //db.Information.Load();
            //db.House.Load();
            //db.Sectors.Load();
            //db.Undersectors.Load();
            var permanent = from i in db.Information
                            join h in db.House on i.house_id equals h.id
                            join s in db.Sectors on i.sector_id equals s.id
                            join us in db.Undersectors on i.undersector_id equals us.id
                            join p in db.Parts on i.part_id equals p.id
                            select new { House_Name = h.house_name, Part_Name = p.part_name, Sector_Name = s.sector_name, Undersector_Name = us.undersector_name, Breaking = i.breaking, Repairs = i.repairs, Start_Date = i.date_begine, End_Date = i.date_end, Cost = i.cost };
            dataGridView1.DataSource = permanent.ToList();
            //dataGridView1.DataSource = db.Information.Local.ToBindingList();
            //dataGridView1.DataSource = db.Database.SqlQuery<List>("select * from information",null);

            //ds = db.Database.SqlQuery("select * from Information",null);


            /*
             select house_name,sector_name,data,id from houses,sectors,information where 
             */
        }
    }
}
