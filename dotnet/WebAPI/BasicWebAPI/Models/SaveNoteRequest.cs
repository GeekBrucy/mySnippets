using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicWebAPI.Models;

public record SaveNoteRequest(string Title, string Content);