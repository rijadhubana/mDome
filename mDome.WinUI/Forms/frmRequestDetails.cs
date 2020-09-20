using mDome.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mDome.WinUI.Forms
{
    public partial class frmRequestDetails : Form
    {
        private Model.Request _selectedRequest;
        private readonly APIService _requestService = new APIService("Request");
        private readonly APIService _notificationService = new APIService("Notification");
        public event EventHandler<object> refreshHandler;
        public frmRequestDetails(Model.Request request)
        {
            _selectedRequest = request;
            InitializeComponent();
        }

        private void frmRequestDetails_Load(object sender, EventArgs e)
        {
            txtRequestText.Text = _selectedRequest.RequestText;
            txtDate.Text = _selectedRequest.RequestDate.ToString();
        }

        private void txtNotify_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNotify.Text))
            {
                errorProvider.SetError(txtNotify, "Required field");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtNotify, null);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                var confirmResult = MessageBox.Show("Submit Changes?",
                                     "Confirm",
                                     MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    string solved = "";
                    if (chbSolved.Checked == true)
                    {
                        solved = "Request solved! Message from admin: \n";
                    }
                    else solved = "Request denied! Message from admin \n";
                    NotificationUpsertRequest requestAdd = new NotificationUpsertRequest()
                    {
                        UserId = _selectedRequest.UserId,
                        NotifDateTime = DateTime.Now,
                        NotifText = solved + txtNotify.Text
                    };
                    await _notificationService.Insert<Model.Notification>(requestAdd);
                    await _requestService.Delete<Model.Request>(_selectedRequest.RequestId);
                    MessageBox.Show("Task successful");
                    refreshHandler?.Invoke(this,null);
                    this.Close();
                }
                    
            }
            

        }
    }
}
