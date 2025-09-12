/**
 * @name Look for `if` statements without `else` branch
 * @description Sample CodeQL query.
 * @kind problem
 * @problem.severity warning
 * @id csharp/example/if-no-else
 * @tags maintainability
 */

import csharp

from IfStmt ifs
where not exists(ifs.getElse())
select ifs, "This 'if' statement does not have an 'else' branch."