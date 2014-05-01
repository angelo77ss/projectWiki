using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wiki.Common.Util;

namespace Wiki.Common.Classes
{
    public class Coment
    {
		[MappingSettings(false)]
        public int ComentId { get; set; }
		
		[MappingSettings(false)]
        public int ComentReferenceId { get; set; }
		
        [MappingSettings(false, MappingSettingsAttribute.MappingType.Complex)]
        public Post Post { get; set; }
		
		[MappingSettings(false, MappingSettingsAttribute.MappingType.Complex)]
        public User User { get; set; }
		
		[MappingSettings(false)]
        public string ComentText { get; set; }
		
		[MappingSettings(false)]
        public DateTime CreatedDate { get; set; }
		
		[MappingSettings(false)]
        public bool Active { get; set; }
		
		[MappingSettings(false)]
        public DateTime DeletedDate { get; set; }
		
		#region Resultados para operaciones
		
		[MappingSettings(false)]
        public bool OperationResult { get; set; }
		
		[MappingSettings(false)]
        public string OperationMessage { get; set; }

		#endregion	
		
		/// <summary>
        /// Constructor vacio
        /// </summary>
        public Coment()
        {
            this.User = new User();
			this.Post = new Post();
        }

        /// <summary>
        /// Constructor con ID
        /// </summary>
        /// <param name="id">Id del objeto</param>
        public Coment(int id)
        {
            this.ComentId = id;
            this.User = new User();
            this.Post = new Post();
        }
 
    }
}
