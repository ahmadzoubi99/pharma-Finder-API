using PharmaFinder.Core.Data;
using PharmaFinder.Core.Repository;
using PharmaFinder.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaFinder.Infra.Service
{
    public class RoleService:IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public List<Role> GetAllRoles()
        {
            return _roleRepository.GetAllRoles();
        }

        public Role GetRoleById(decimal id)
        {
            return _roleRepository.GetRoleById(id);
        }

        public void CreateRole(Role roleData)
        {
            _roleRepository.CreateRole(roleData);
        }

        public void UpdateRole(Role roleData)
        {
            _roleRepository.UpdateRole(roleData);
        }

        public void DeleteRole(decimal id)
        {
            _roleRepository.DeleteRole(id);
        }
    }
}
