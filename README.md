Here is how you can set up the application

Fisrt open the aplication with visual studio.
Go to Techhrms.WebApp and open settings.json
Change server name from DESKTOP-2JJFP7U to your Sql server name
This connection string need to change and in Techhrms.Tests

After you made this, open packeage manager consule and write this code
add-migration fisrtMigration

after migration finished write this one

update-database

And the database will be create automaticly in your sql server

Than Run application and use it


Thank you
