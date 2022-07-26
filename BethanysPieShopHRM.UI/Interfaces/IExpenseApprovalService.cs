using System.Threading.Tasks;
using BethanysPieShopHRM.Shared;

namespace BethanysPieShopHRM.UI.Services
{
    public interface IExpenseApprovalService
    {
        Task<ExpenseStatus> GetExpenseStatus(Expense expense);
    }
}