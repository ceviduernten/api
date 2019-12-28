using System.Collections.Generic;

namespace DUR.Api.Presentation.ResourceModel
{
    public class ContactGroupRM
    {
        public List<ContactRM> Jungschar { get; set; }
        public List<ContactRM> Froeschli { get; set; }
        public List<ContactRM> Verein { get; set; }
    }
}
