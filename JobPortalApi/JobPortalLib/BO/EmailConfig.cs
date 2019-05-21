using System;
using System.Collections.Generic;
using System.Text;

namespace JobPortalLib.BO
{
	public class EmailConfig
	{
		public int EConfigID { get; set; }
		public string FormName { get; set; }
		public string MailFrom { get; set; }
		public string MailCC { get; set; }
		public string MailBCC { get; set; }
		public string MailSubject { get; set; }
		public string MailPurpose { get; set; }
		public string MailContent { get; set; }
		public char MType { get; set; }
		public int Enteredby { get; set; }
		public Nullable<System.DateTime> Entereddate { get; set; }
		public int Updatedby { get; set; }
		public Nullable<System.DateTime> Updateddate { get; set; }
		public string deleted { get; set; }
		public int SeqNo { get; set; }
	}
}
