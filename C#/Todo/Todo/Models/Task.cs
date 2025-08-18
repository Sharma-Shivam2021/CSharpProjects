using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Models;

public class Tasks
{
    public int Id { get; set; }
    public string? Day { get; set; }
    public string? TaskName { get; set; }
}
