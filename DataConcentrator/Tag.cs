using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace DataConcentrator
{

    
    public class Tag : INotifyPropertyChanged
    {
        #region Fields
        private string id;
        private string description;
        private string tagType;

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Properties
        [Key]
        [MaxLength(30)]
        public string Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }
        [MaxLength(50)]
        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
                OnPropertyChanged("Description");
            }

        }

        public string TagType
        {
            get
            {
                return tagType;
            }

            set
            {
                tagType = value;
                OnPropertyChanged("TagType");
            }
        }
        #endregion

        #region Methods
        protected void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
        #endregion
    }


}