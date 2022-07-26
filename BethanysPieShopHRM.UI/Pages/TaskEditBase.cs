using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethanysPieShopHRM.Shared;
using BethanysPieShopHRM.UI.Services;
using Microsoft.AspNetCore.Components;

namespace BethanysPieShopHRM.UI.Pages
{
    public class TaskEditBase : ComponentBase
    {
        public bool Saved { get; set; } = false;

        public HRTask Task { get; set; } = new HRTask();

        public string Message { get; set; }

        protected string EmployeeId = "1";

        [Inject]
        private ITaskDataService taskService { get; set; }

        [Inject]
        private NavigationManager navManager { get; set; }

        [Inject]
        public IEmployeeDataService EmployeeDataService { get; set; }

        public List<Employee> Employees { get; set; } = new List<Employee>();

        protected override async Task OnInitializedAsync()
        {
            Saved = false;
            Employees = (await EmployeeDataService.GetAllEmployees()).ToList();
        }

        protected async Task HandleValidSubmit()
        {
            Task.AssignedTo = int.Parse(EmployeeId);
            var result = await taskService.AddTask(Task);

            if (result != null)
            {
                navManager.NavigateTo("/");
            }
            else
            {
                Message = "An error has occured";
            }
        }
    }
}