# Databases Basics - MS SQL Server

<br/>

---

## <a href="https://github.com/radrex/SoftuniCourses/tree/master/C%23%20Web%20Developer/C%23%20DB/01.Databases%20Basics%20-%20MS%20SQL%20Server/01.Database%20Introduction%2C%20Data%20Definition%20and%20Datatypes">01. Database Introduction, Data Definition and Datatypes</a>

<table>
  <thead>
    <tr>
      <th colspan="10" style="text-align:center;">Lab</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td><b>01.</b></td>
      <td><a href="https://github.com/radrex/SoftuniCourses/blob/0b8865d8c7c6c1946d0ae7f10b4cd0a9c0edd2aa/C%23%20Web%20Developer/C%23%20DB/01.Databases%20Basics%20-%20MS%20SQL%20Server/01.Database%20Introduction%2C%20Data%20Definition%20and%20Datatypes/Lab.sql#L4">Create a Database</a></td>
      <td><b>02.</b></td>
      <td><a href="https://github.com/radrex/SoftuniCourses/blob/0b8865d8c7c6c1946d0ae7f10b4cd0a9c0edd2aa/C%23%20Web%20Developer/C%23%20DB/01.Databases%20Basics%20-%20MS%20SQL%20Server/01.Database%20Introduction%2C%20Data%20Definition%20and%20Datatypes/Lab.sql#L12">Create Tables</a></td>
      <td><b>03.</b></td>
      <td><a href="https://github.com/radrex/SoftuniCourses/blob/0b8865d8c7c6c1946d0ae7f10b4cd0a9c0edd2aa/C%23%20Web%20Developer/C%23%20DB/01.Databases%20Basics%20-%20MS%20SQL%20Server/01.Database%20Introduction%2C%20Data%20Definition%20and%20Datatypes/Lab.sql#L31">Insert Sample Data into Database</a></td>
      <td><b>04.</b></td>
      <td><a href="https://github.com/radrex/SoftuniCourses/blob/0b8865d8c7c6c1946d0ae7f10b4cd0a9c0edd2aa/C%23%20Web%20Developer/C%23%20DB/01.Databases%20Basics%20-%20MS%20SQL%20Server/01.Database%20Introduction%2C%20Data%20Definition%20and%20Datatypes/Lab.sql#L49">Create a Function</a></td>
      <td><b>05.</b></td>
      <td><a href="https://github.com/radrex/SoftuniCourses/blob/0b8865d8c7c6c1946d0ae7f10b4cd0a9c0edd2aa/C%23%20Web%20Developer/C%23%20DB/01.Databases%20Basics%20-%20MS%20SQL%20Server/01.Database%20Introduction%2C%20Data%20Definition%20and%20Datatypes/Lab.sql#L62">Create Procedures</a></td>
    </tr>
    <tr>
      <td><b>06.</b></td>
      <td><a href="https://github.com/radrex/SoftuniCourses/blob/0b8865d8c7c6c1946d0ae7f10b4cd0a9c0edd2aa/C%23%20Web%20Developer/C%23%20DB/01.Databases%20Basics%20-%20MS%20SQL%20Server/01.Database%20Introduction%2C%20Data%20Definition%20and%20Datatypes/Lab.sql#L101">Create Transactions Table and a Trigger</a></td>
      <td colspan="8"></td>
    </tr>
  </tbody>
  <thead>
    <tr>
      <th colspan="10" style="text-align:center;"><br>Exercise</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td><b>01.</b></td>
      <td><a href="https://github.com/radrex/SoftuniCourses/blob/76a332563c5a94d3c2ffcbbd717bac8bc9a87866/C%23%20Web%20Developer/C%23%20DB/01.Databases%20Basics%20-%20MS%20SQL%20Server/01.Database%20Introduction%2C%20Data%20Definition%20and%20Datatypes/MinionsDB.sql#L4">Create Database</a></td>
      <td><b>02.</b></td>
      <td><a href="https://github.com/radrex/SoftuniCourses/blob/76a332563c5a94d3c2ffcbbd717bac8bc9a87866/C%23%20Web%20Developer/C%23%20DB/01.Databases%20Basics%20-%20MS%20SQL%20Server/01.Database%20Introduction%2C%20Data%20Definition%20and%20Datatypes/MinionsDB.sql#L11">Create Tables</a></td>
      <td><b>03.</b></td>
      <td><a href="https://github.com/radrex/SoftuniCourses/blob/76a332563c5a94d3c2ffcbbd717bac8bc9a87866/C%23%20Web%20Developer/C%23%20DB/01.Databases%20Basics%20-%20MS%20SQL%20Server/01.Database%20Introduction%2C%20Data%20Definition%20and%20Datatypes/MinionsDB.sql#L26">Alter Minions Table</a></td>
      <td><b>04.</b></td>
      <td><a href="https://github.com/radrex/SoftuniCourses/blob/76a332563c5a94d3c2ffcbbd717bac8bc9a87866/C%23%20Web%20Developer/C%23%20DB/01.Databases%20Basics%20-%20MS%20SQL%20Server/01.Database%20Introduction%2C%20Data%20Definition%20and%20Datatypes/MinionsDB.sql#L30">Insert Records in Both Tables</a></td>
      <td><b>05.</b></td>
      <td><a href="https://github.com/radrex/SoftuniCourses/blob/76a332563c5a94d3c2ffcbbd717bac8bc9a87866/C%23%20Web%20Developer/C%23%20DB/01.Databases%20Basics%20-%20MS%20SQL%20Server/01.Database%20Introduction%2C%20Data%20Definition%20and%20Datatypes/MinionsDB.sql#L42">Truncate Table Minions</a></td>
    </tr>
    <tr>
      <td><b>06.</b></td>
      <td><a href="https://github.com/radrex/SoftuniCourses/blob/76a332563c5a94d3c2ffcbbd717bac8bc9a87866/C%23%20Web%20Developer/C%23%20DB/01.Databases%20Basics%20-%20MS%20SQL%20Server/01.Database%20Introduction%2C%20Data%20Definition%20and%20Datatypes/MinionsDB.sql#L45">Drop All Tables</a></td>
      <td><b>07.</b></td>
      <td><a href="https://github.com/radrex/SoftuniCourses/blob/76a332563c5a94d3c2ffcbbd717bac8bc9a87866/C%23%20Web%20Developer/C%23%20DB/01.Databases%20Basics%20-%20MS%20SQL%20Server/01.Database%20Introduction%2C%20Data%20Definition%20and%20Datatypes/MinionsDB.sql#L49">Create Table People</a></td>
      <td><b>08.</b></td>
      <td><a href="https://github.com/radrex/SoftuniCourses/blob/76a332563c5a94d3c2ffcbbd717bac8bc9a87866/C%23%20Web%20Developer/C%23%20DB/01.Databases%20Basics%20-%20MS%20SQL%20Server/01.Database%20Introduction%2C%20Data%20Definition%20and%20Datatypes/MinionsDB.sql#L68">Create Table Users</a></td>
      <td><b>09.</b></td>
      <td><a href="https://github.com/radrex/SoftuniCourses/blob/76a332563c5a94d3c2ffcbbd717bac8bc9a87866/C%23%20Web%20Developer/C%23%20DB/01.Databases%20Basics%20-%20MS%20SQL%20Server/01.Database%20Introduction%2C%20Data%20Definition%20and%20Datatypes/MinionsDB.sql#L85">Change Primary Key</a></td>
      <td><b>10.</b></td>
      <td><a href="https://github.com/radrex/SoftuniCourses/blob/76a332563c5a94d3c2ffcbbd717bac8bc9a87866/C%23%20Web%20Developer/C%23%20DB/01.Databases%20Basics%20-%20MS%20SQL%20Server/01.Database%20Introduction%2C%20Data%20Definition%20and%20Datatypes/MinionsDB.sql#L92">Add Check Constraint</a></td>
    </tr>
  </tbody>
  <tbody>
    <tr>
      <td><b>11.</b></td>
      <td><a href="https://github.com/radrex/SoftuniCourses/blob/76a332563c5a94d3c2ffcbbd717bac8bc9a87866/C%23%20Web%20Developer/C%23%20DB/01.Databases%20Basics%20-%20MS%20SQL%20Server/01.Database%20Introduction%2C%20Data%20Definition%20and%20Datatypes/MinionsDB.sql#L96">Set Default Value of a Field</a></td>
      <td><b>12.</b></td>
      <td><a href="https://github.com/radrex/SoftuniCourses/blob/76a332563c5a94d3c2ffcbbd717bac8bc9a87866/C%23%20Web%20Developer/C%23%20DB/01.Databases%20Basics%20-%20MS%20SQL%20Server/01.Database%20Introduction%2C%20Data%20Definition%20and%20Datatypes/MinionsDB.sql#L100">Set Unique Field</a></td>
      <td colspan="8"></td>
    </tr>
  </tbody>
</table>

