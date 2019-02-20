using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NicholasNyland.Models
{
    public class Art
    {
        public string Name { get; set; }
        
        public DateTime Date { get; set; }
        
        /// <summary>
        /// 1 = Painting
        /// 2 = Sculpture
        /// 3 = Installation
        /// </summary>
        public int Medium { get; set; }
        
        public string Description { get; set; }
        
        public string Path { get; set; }
        
        public bool Equals(Art piece)
        {
            return this.Name == piece.Name &&
                   this.Date == piece.Date &&
                   this.Medium == piece.Medium;
        }

        /// <summary>
        /// Returns medium as a string.
        /// </summary>
        /// <returns></returns>
        public string GetMedium()
        {
            if (this.Medium == 1)
            {
                return "Painting";
            } 
            else if (this.Medium == 2)
            {
                return "Sculpture";
            }
            else if (this.Medium == 3)
            {
                return "Installation";
            }
            return null;
        }

        /// <summary>
        /// Sets medium based on string value.
        /// Returns true if correctly set.
        /// </summary>
        /// <param name="medium"></param>
        /// <returns></returns>
        public bool SetMedium(string medium)
        {
            medium = medium.Trim().ToLower();
            if (medium == "painting")
            {
                this.Medium = 1;
                return true;
            }
            else if (medium == "sculpture")
            {
                this.Medium = 2;
                return true;
            }
            else if (medium == "installation")
            {
                this.Medium = 3;
                return true;
            }            
            return false;
        }

        /// <summary>
        /// Sets path by file name and type.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="fileType"></param>
        public void SetPathByName(string fileName, string fileType)
        {
            this.Path = "~/Images/" + fileName + "." + fileType;
        }
    }
}