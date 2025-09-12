/**
 * @name Look for `if` statements without `else` branch in Program.cs
 * @description Sample CodeQL query that only scans Program.cs.
 * @kind problem
 * @problem.severity warning
 * @id csharp/example/if-no-else-program
 * @tags maintainability
 */

import csharp

from IfStmt ifs, File f
where
  not exists(ifs.getElse()) and
  f.getBaseName() = "Program.cs" and
  ifs.getFile() = f
select ifs, "This 'if' statement in Program.cs does not have an 'else' branch."