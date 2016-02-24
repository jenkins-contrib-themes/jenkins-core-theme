using System;
using System.Collections.Specialized;

namespace S22.Mail.SerializableMailMessage {
	[Serializable]
	public class SerializableContentDisposition {
		public static implicit operator System.Net.Mime.ContentDisposition(SerializableContentDisposition disposition) {
			if (disposition == null)
				return null;
			System.Net.Mime.ContentDisposition d = new System.Net.Mime.ContentDisposition();

			d.CreationDate = disposition.CreationDate;
			d.DispositionType = disposition.DispositionType;
			d.FileName = disposition.FileName;
			d.Inline = disposition.Inline;
			d.ModificationDate = disposition.ModificationDate;
			foreach (string k in disposition.Parameters.Keys)
				d.Parameters.Add(k, disposition.Parameters[k]);
			d.ReadDate = disposition.ReadDate;
			d.Size = disposition.Size;
			return d;
		}

		public static implicit operator SerializableContentDisposition(System.Net.Mime.ContentDisposition disposition) {
			if (disposition == null)
				return null;
			return new SerializableContentDisposition(disposition);
		}

		private SerializableContentDisposition(System.Net.Mime.ContentDisposition disposition) {
			CreationDate = disposition.CreationDate;
			DispositionType = disposition.DispositionType;
			FileName = disposition.FileName;
			Inline = disposition.Inline;
			ModificationDate = disposition.ModificationDate;
			Parameters = new StringDictionary();
			foreach (string k in disposition.Parameters.Keys)
				Parameters.Add(k, disposition.Parameters[k]);
			ReadDate = disposition.ReadDate;
			Size = disposition.Size;
		}

		public DateTime CreationDate { get; set; }
		public string DispositionType { get; set; }
		public string FileName { get; set; }
		public bool Inline { get; set; }
		public DateTime ModificationDate { get; set; }
		public StringDictionary Parameters { get; private set; }
		public DateTime ReadDate { get; set; }
		public long Size { get; set; }
	}
}
