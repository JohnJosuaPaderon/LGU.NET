<!DOCTYPE html>
<html lang="en">
<head>
     <meta charset="UTF-8">
     <meta name="viewport" content="width=device-width, initial-scale=1.0">
     <meta http-equiv="X-UA-Compatible" content="ie=edge">
     <title>LGU.NET</title>
     <link rel="stylesheet" href="css/index.css" />
</head>
<body>
     <div class="title">LGU.NET</div>
     <div class="section-1">Database Structure</div>

     <!-- Schema: Core -->
     <div class="section-2">Schema: Core</div>
     <table cellspacing="0px">
          <!-- Headers -->
          <tr>
               <th class="field-column">Field</th>
               <th class="data-type-column">Data Type</th>
               <th class="remarks-column">Remarks</th>
          </tr>

          <!-- Core.Gender -->
          <tr>
               <td colspan="3" class="header">Gender</td>
          </tr>
          <tr>
               <td>Id</td>
               <td>SMALLINT</td>
               <td>Primary Key, Unsigned, Auto Increment</td>
          </tr>
          <tr>
               <td>Value</td>
               <td>VARCHAR(10)</td>
               <td>Not Null, Unique</td>
          </tr>

          <!-- Core.Person -->
          <tr>
               <td colspan="3" class="header">Person</td>
          </tr>
          <tr>
               <td>Id</td>
               <td>BIGINT</td>
               <td>Primary Key, Unsigned, Auto Increment</td>
          </tr>
          <tr>
               <td>FirstName</td>
               <td>VARCHAR(75)</td>
               <td>Not Null</td>
          </tr>
          <tr>
               <td>MiddleName</td>
               <td>VARCHAR(75)</td>
               <td></td>
          </tr>
          <tr>
               <td>LastNane</td>
               <td>VARCHAR(75)</td>
               <td>Not Null</td>
          </tr>
          <tr>
               <td>NameSuffix</td>
               <td>VARCHAR(5)</td>
               <td></td>
          </tr>
          <tr>
               <td>BirthDate</td>
               <td>DATE</td>
               <td>Not Null</td>
          </tr>
          <tr>
               <td>Gender</td>
               <td>SMALLINT</td>
               <td>Reference: <span class="db-entity">Gender.Id</span>, Unsigned</td>
          </tr>
          <tr>
               <td>Deleted</td>
               <td>BIT</td>
               <td>Not Null, Default: TRUE</td>
          </tr>
          <tr>
               <td>CreatedBy</td>
               <td>VARCHAR(100)</td>
               <td>Not Null, Default: 'System'</td>
          </tr>
          <tr>
               <td>DateCreated</td>
               <td>TIMESTAMP</td>
               <td>Not Null, Default: NOW()</td>
          </tr>
          <tr>
               <td>ModifiedBy</td>
               <td>VARCHAR(100)</td>
               <td></td>
          </tr>
          <tr>
               <td>DateModified</td>
               <td>TIMESTAMP</td>
               <td></td>
          </tr>

          <!-- Core.UserStatus -->
          <tr>
               <td colspan="3" class="header">UserStatus</td>
          </tr>
          <tr>
               <td>Id</td>
               <td>SMALLINT</td>
               <td>Primary Key, Unsigned, Auto Increment</td>
          </tr>
          <tr>
               <td>Value</td>
               <td>VARCHAR(20)</td>
               <td>Not Null, Unique</td>
          </tr>

          <!-- Core.UserType -->
          <tr>
               <td colspan="3" class="header">UserType</td>
          </tr>
          <tr>
               <td>Id</td>
               <td>SMALLINT</td>
               <td>Primary Key, Unsigned, Auto Increment</td>
          </tr>
          <tr>
               <td>Value</td>
               <td>VARCHAR(20)</td>
               <td>Not Null, Unique</td>
          </tr>

          <!-- Core.User -->
          <tr>
               <td colspan="3" class="header">User</td>
          </tr>
          <tr>
               <td>Id</td>
               <td>BIGINT</td>
               <td>Primary Key, Unsigned, Auto Increment</td>
          </tr>
          <tr>
               <td>PersonId</td>
               <td>BIGINT</td>
               <td>Reference: <span class="db-entity">Person.Id</span>, Unsigned</td>
          </tr>
          <tr>
               <td>DisplayName</td>
               <td>VARCHAR(25)</td>
               <td>Not Null</td>
          </tr>
          <tr>
               <td>Status</td>
               <td>SMALLINT</td>
               <td>Reference: <span class="db-entity">UserStatus.Id</span>, Not Null, Unsigned</td>
          </tr>
          <tr>
               <td>Type</td>
               <td>SMALLINT</td>
               <td>Reference: <span class="db-entity">UserType.Id</span>, Not Null, Unsigned</td>
          </tr>
          <tr>
               <td>Deleted</td>
               <td>BIT</td>
               <td>Not Null, Default: TRUE</td>
          </tr>
          <tr>
               <td>CreatedBy</td>
               <td>VARCHAR(100)</td>
               <td>Not Null, Default: 'System'</td>
          </tr>
          <tr>
               <td>DateCreated</td>
               <td>TIMESTAMP</td>
               <td>Not Null, Default: NOW()</td>
          </tr>
          <tr>
               <td>ModifiedBy</td>
               <td>VARCHAR(100)</td>
               <td></td>
          </tr>
          <tr>
               <td>DateModified</td>
               <td>TIMESTAMP</td>
               <td></td>
          </tr>

          <!-- Core.UserCredentials -->
          <tr>
               <td colspan="3" class="header">UserCredentials</td>
          </tr>
          <tr>
               <td>Id</td>
               <td>BIGINT</td>
               <td>Primary Key, Reference: <span class="db-entity">User.Id</span>, Unsigned</td>
          </tr>
          <tr>
               <td>Username</td>
               <td>VARCHAR(128)</td>
               <td>Not Null</td>
          </tr>
          <tr>
               <td>Password</td>
               <td>VARCHAR(128)</td>
               <td>Not Null</td>
          </tr>
     </table>

     <!-- Schema: HumanResource -->
     <div class="section-2">Schema: HumanResource</div>
     <table cellspacing="0px">
          <!-- Headers -->
          <tr>
               <th class="field-column">Field</th>
               <th class="data-type-column">Data Type</th>
               <th class="remarks-column">Remarks</th>
          </tr>

          <!-- HumanResource.EmploymentStatus -->
          <tr>
               <td colspan="3" class="header">EmploymentStatus</td>
          </tr>
     </table>
</body>
</html>
