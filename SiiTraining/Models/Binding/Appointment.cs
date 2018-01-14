using Microsoft.AspNetCore.Mvc;
using SiiTraining.Code.Binding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiiTraining.Models.Binding
{
    public class Appointment
    {
        public int Id { get; set; }
        public string Title { get; set; }

        [ModelBinder(BinderType = typeof(DateAndTimeModelBinder))]
        public DateTime AppointmentDate { get; set; }
    }
}
