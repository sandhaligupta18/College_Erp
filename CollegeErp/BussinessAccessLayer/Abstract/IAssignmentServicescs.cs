﻿using ModelAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessAccessLayer.Abstract
{
    public interface IAssignmentServicescs
    {
        public Task<bool> AddAssignment(AssignmentViews assignment);

        public Task<IEnumerable<Assignment>> GetAssignmentDetails();
        public Task<Assignment> GetAssignment(string SubjectId);
        public Task<bool> UpdateAssignment(Assignment assignment);
        public Task<bool> DeleteAssignment(string SubjectId);


    }
}
