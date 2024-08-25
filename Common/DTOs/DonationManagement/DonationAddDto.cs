using Common.Enums.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs.DonationManagement
{
    public record DonationAddDto
    (              
        string Name,
        string Passaword,
        string Email,
        Role Role
       
        );
   
}
