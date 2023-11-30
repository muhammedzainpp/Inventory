using Domain;
using FluentValidation;
using IMS.Application.InterFaces;
using IMS.Application.Repositories.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Application.Repositories.Validation
{

    public class InventoryValidator : AbstractValidator<InvetoryDto>
    {
        private readonly IAppDbContext context;
        public InventoryValidator(IAppDbContext context)
        {
            this.context = context;
            RuleFor(x => x.InventoryName).Must(IsInventoryNameExist);
        }
        public bool IsInventoryNameExist(InvetoryDto inventory ,string name)
        {
            //var isExist = context.Inventories.FirstOrDefault(x => x.InventoryName == name) != null;
            //var isNew = inventory.InventoryId == 0;
            if (context.Inventories.FirstOrDefault(x => x.InventoryName == name) != null)
            {
                if (context.Inventories.First(x => x.InventoryName == name).InventoryId == inventory.InventoryId)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if(context.Inventories.FirstOrDefault(x=>x.InventoryName==name) ==null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
