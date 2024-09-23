"Trong file app.config, chỉnh sửa như đoạn code phía dưới"

```
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
    <startup> 
        <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.7.2" />
    </startup>
	<connectionStrings>
		<add name="AnimalManagementDbConnectionString"
         connectionString="Insert your connection string here!"
         providerName="System.Data.SqlClient" />
	</connectionStrings>
</configuration>
```
