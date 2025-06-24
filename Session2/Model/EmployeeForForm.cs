using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session2.Model
{
    public class EmployeeForForm
    {
        private int? idemployeeforform;
        public int? IdEmployeeForForm
        {
            get { return idemployeeforform; }
            set { idemployeeforform = value; }
        }
        private string? surname_;
        public string? Surname_
        {
            get { return surname_; }
            set { surname_ = value; }
        }
        private string? firstname_;
        public string? Firstname_
        {
            get { return firstname_; }
            set { firstname_ = value; }
        }
        private string? secondname_;
        public string? Secondname_
        {
            get { return secondname_; }
            set { secondname_ = value; }
        }
        private string? position_;
        public string? Position_
        {
            get { return position_; }
            set { position_ = value; }
        }
        private string? phonework_;
        public string? Phonework_
        {
            get { return phonework_; }
            set { phonework_ = value; }
        }
        private string? phone_;
        public string? Phone_
        {
            get { return phone_; }
            set { phone_ = value; }
        }
        private string? email_;
        public string? Email_
        {
            get { return email_; }
            set { email_ = value; }
        }
        private string? other_;
        public string? Other_
        {
            get { return other_; }
            set { other_ = value; }
        }
        private DateOnly? birthday_;
        public DateOnly? Birthday_
        {
            get { return birthday_; }
            set { birthday_ = value; }
        }
        private string? department_;
        public string? Department_
        {
            get { return department_; }
            set { department_ = value; }
        }
        private string? boss_;
        public string? Boss_
        {
            get { return boss_; }
            set { boss_ = value; }
        }
        private string? helper_;
        public string? Helper_
        {
            get { return helper_; }
            set { helper_ = value; }
        }
        private string? cabinet_;
        public string? Cabinet_
        {
            get { return cabinet_; }
            set { cabinet_ = value; }
        }
    }
}
