using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mumblr.SharedKernel.Primitives;

public readonly record struct Result(bool Success, string? Error = null)
{
    public static Result Ok() => new(true);

    public static Result Fail(string error) => new(false, error);
}
