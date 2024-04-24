using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebRazor.Service.Models;
using WebRazor.Service.Services;

namespace WebRazor.Pages
{
    public class TasksModel : PageModel
    {
        private readonly ITaskServices _taskServices;

        public TasksModel(ITaskServices services)
        {
            _taskServices = services;
        }

        public List<WebRazor.Service.Models.TasksModel> TaskList { get; set; }
        [BindProperty]

        public bool CompleteCheck { get; set; }

        public void OnGet()
        {
            TaskList = _taskServices.ShowAllTask();
        }

        public IActionResult OnPostDeleteButton(int TaskId)
        {
            _taskServices.DeleteTaskById(TaskId);
            return RedirectToPage("/Index");
        }
        public IActionResult OnPostSave(int TaskId)
        {
            if (CompleteCheck == true)
            {
                _taskServices.TaskIsCompleted(TaskId);
                return RedirectToPage("/Index");
            }
            return RedirectToPage("/Index");
        }
    }
}
