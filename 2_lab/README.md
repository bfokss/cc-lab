# This is 2_lab folder

Tasks:
<ol>
    <li>Create SQL Database on Azure</li>
    <li>Create .NET Core app and connect with database</li>
    <li>Create initial migration</li>
</ol>

___

*Extra tasks*
<ol>
    <li>Create controller</li>
    <li>Add CRUD functionality</li>
</ol>

___

Additional informations:
<ul>
    <li> To run application please clone this repository </li>
    <li> To get informations from Database you can use Azure Data Studio or httprepl </li>
    <li> When using Azure Data Studio connect to Azure database with your SQL credentials and use query on TodoItems table </li>
    <li> When using httprepl: 
        <ul>
            <li> Press Ctrl+F5 to run app or <code> dotnet run </code> in project directory  </li>
            <li> In terminal: <code> httprepl https://localhost:YOUR_APP_PORT/api/todoitems </code> </li>
            <li> In terminal: <code> get </code> </li>
        </ul> 
    </li>
</ul>
<br>

___


<i>Example post:</i>

<img src="screenshots/post.png" width=600>

<br>

<i>Example get:</i>

<img src="screenshots/get.png" width=600>

<i>Example Azure Data Studio query result:</i>

<img src="screenshots/ads_table_result.png" width=600>
