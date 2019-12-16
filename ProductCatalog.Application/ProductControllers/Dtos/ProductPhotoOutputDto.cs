using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCatalog.Application.ProductControllers.Dtos
{
    public class ProductPhotoOutputDto
    {
        public int ProductId { get; set; }
        public string MimeType { get; set; }

        public string AltAttribute { get; set; }
        
        public string TitleAttribute { get; set; }
        public byte[] BinaryData { get; set; }

        public int PhotoId { get; set; }
    }
}
