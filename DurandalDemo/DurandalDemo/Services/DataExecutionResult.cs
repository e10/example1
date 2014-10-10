using System.Collections.Generic;

namespace DurandalDemo.Services
{
    public class DataExecutionResult<T>
    {
        public int RowsAffected { get; set; }
        public T Entity { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}