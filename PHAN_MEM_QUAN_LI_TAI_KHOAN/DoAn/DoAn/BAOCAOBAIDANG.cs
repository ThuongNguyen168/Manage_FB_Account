using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

namespace DoAn
{
    public partial class BAOCAOBAIDANG : Form
    {
        public BAOCAOBAIDANG()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            report rp = new report();

            ParameterValues param_from_date = new ParameterValues();
            ParameterDiscreteValue pdv_from_date = new ParameterDiscreteValue();
            pdv_from_date.Value = from_date.Value;
            param_from_date.Add(pdv_from_date);

            ParameterValues param_to_date = new ParameterValues();
            ParameterDiscreteValue pdv_to_date = new ParameterDiscreteValue();
            pdv_to_date.Value = to_date.Value;
            param_to_date.Add(pdv_to_date);

            rp.DataDefinition.ParameterFields[0].ApplyCurrentValues(param_from_date);
            rp.DataDefinition.ParameterFields[1].ApplyCurrentValues(param_to_date);

            crystalReportViewer.ReportSource = rp;
            crystalReportViewer.Refresh();
        }
    }
}
