using Microsoft.EntityFrameworkCore.Migrations;

namespace Acupunctuur.Migrations
{
    public partial class Pages_IsEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsEmail",
                table: "Pages",
                nullable: false,
                defaultValue: false);

            migrationBuilder.Sql(
                "INSERT INTO Contents (RawHtml) VALUES " +
                "('<p>Beste @{FIRST_NAME},</p><p>U heeft zichzelf succesvol aangemeld bij Prikkebeen Acupunctuur. Hiermee kunt u nieuwe reserveringen maken en uw reserveringen bijhouden.</p><p>Wij hebben de volgende gegevens van u ontvangen:</p><div><table><tr><td><b>Voornaam</b></td><td>@{FIRST_NAME}</td></tr><tr><td><b>Achternaam</b></td><td>@{LAST_NAME}</td></tr><tr><td><b>Geboortedatum</b></td><td>@{DATE_OF_BIRTH}</td></tr><tr><td><b>Adres</b></td><td>@{HOUSE_ADDRESS} @{HOUSE_NUMBER}</td></tr><tr><td><b>Postcode</b></td><td>@{POSTAL_CODE}</td></tr><tr><td><b>Woonplaats</b></td><td>@{CITY}</td></tr><tr><td><b>Land</b></td><td>@{COUNTRY}</td></tr><tr><td><b>Telefoonnummer</b></td><td>@{TELEPHONE_NUMBER}</td></tr></table></div><br><p>Met vriendelijke groet,<br><br><b>Berry Prikkebeen</b><br>Prikkebeen Acupunctuur<br>Winthontlaan 200<br>3526KV Utrecht<br>Tel: 06-38393625</p>')," +
                "('<p>Beste @{FIRST_NAME},</p><p>U heeft een afspraak gemaakt op @{RES_DATE} van @{RES_START_TIME} t/m @{RES_END_TIME}.</p><p>Wilt u deze afspraak annuleren? Dan gelden de volgende regels:</p><div><ul><li>Tot 48 uur voor de afspraak is annuleren kostenloos</li><li>Binnen 48 uur voor de afspraak betaalt u 50% van de behandelkosten als annuleringskosten</li><li>Binnen 1 uur voor de afspraak betaalt u 100% van de behandelkosten als annuleringskosten</li></ul></div><br><p>Met vriendelijke groet,<br><br><b>Berry Prikkebeen</b><br>Prikkebeen Acupunctuur<br>Winthontlaan 200<br>3526KV Utrecht<br>Tel: 06-38393625</p>')," +
                "('<p>Beste @{ADMIN_FIRST_NAME},</p><p>Uw klant, @{FIRST_NAME} @{LAST_NAME}, heeft hun afspraak geannuleerd op @{RES_DATE} van @{RES_START_TIME} t/m @{RES_END_TIME}. Deze reservering is binnen <b>48 uur</b> voor de afspraak geannuleerd. Deze klant zal <b>50%</b> van de behandelkosten moeten betalen.</p><br><p>Met vriendelijke groet,<br><br><b>Berry Prikkebeen</b><br>Prikkebeen Acupunctuur<br>Winthontlaan 200<br>3526KV Utrecht<br>Tel: 06-38393625</p>')," +
                "('<p>Beste @{ADMIN_FIRST_NAME},</p><p>Uw klant, @{FIRST_NAME} @{LAST_NAME}, heeft hun afspraak geannuleerd op @{RES_DATE} van @{RES_START_TIME} t/m @{RES_END_TIME}. Deze reservering is binnen <b>1 uur</b> voor de afspraak geannuleerd. Deze klant zal <b>100%</b> van de behandelkosten moeten betalen.</p><br><p>Met vriendelijke groet,<br><br><b>Berry Prikkebeen</b><br>Prikkebeen Acupunctuur<br>Winthontlaan 200<br>3526KV Utrecht<br>Tel: 06-38393625</p>')," +
                "('<p>Beste @{FIRST_NAME},</p><p>U heeft uw reservering op @{RES_DATE} van @{RES_START_TIME} t/m @{RES_END_TIME} geannuleerd. Hier zijn geen kosten aan verbonden.</p><br><p>Met vriendelijke groet,<br><br><b>Berry Prikkebeen</b><br>Prikkebeen Acupunctuur<br>Winthontlaan 200<br>3526KV Utrecht<br>Tel: 06-38393625</p>')," +
                "('<p>Beste @{FIRST_NAME},</p><p>U heeft uw reservering op @{RES_DATE} van @{RES_START_TIME} t/m @{RES_END_TIME} geannuleerd. U heeft deze reservering geannuleerd binnen <b>48 uur</b> voor de afspraak. Hiervoor betaalt u <b>50%</b> van de behandelkosten als annuleringskosten.</p><br><p>Met vriendelijke groet,<br><br><b>Berry Prikkebeen</b><br>Prikkebeen Acupunctuur<br>Winthontlaan 200<br>3526KV Utrecht<br>Tel: 06-38393625</p>')," +
                "('<p>Beste @{FIRST_NAME},</p><p>U heeft uw reservering op @{RES_DATE} van @{RES_START_TIME} t/m @{RES_END_TIME} geannuleerd. U heeft deze reservering geannuleerd binnen <b>1 uur</b> voor de afspraak. Hiervoor betaalt u <b>100%</b> van de behandelkosten als annuleringskosten.</p><br><p>Met vriendelijke groet,<br><br><b>Berry Prikkebeen</b><br>Prikkebeen Acupunctuur<br>Winthontlaan 200<br>3526KV Utrecht<br>Tel: 06-38393625</p>')," +
                "('<p>Beste @{FIRST_NAME},</p><p>Uw acupuncturist heeft voor u een nieuwe reservering gemaakt op @{RES_DATE} van @{RES_START_TIME} t/m @{RES_END_TIME}.</p><p>Wilt u deze afspraak annuleren? Dan gelden de volgende regels:</p><div><ul><li>Tot 48 uur voor de afspraak is annuleren kostenloos</li><li>Binnen 48 uur voor de afspraak betaalt u 50% van de behandelkosten als annuleringskosten</li><li>Binnen 1 uur voor de afspraak betaalt u 100% van de behandelkosten als annuleringskosten</li></ul></div><br><p>Met vriendelijke groet,<br><br><b>Berry Prikkebeen</b><br>Prikkebeen Acupunctuur<br>Winthontlaan 200<br>3526KV Utrecht<br>Tel: 06-38393625</p>')," +
                "('<p>Beste @{FIRST_NAME},</p><p>Uw acupuncturist heeft uw reservering op @{RES_DATE} van @{RES_START_TIME} t/m @{RES_END_TIME} geannuleerd. Hier zijn geen kosten aan verbonden.</p><br><p>Met vriendelijke groet,<br><br><b>Berry Prikkebeen</b><br>Prikkebeen Acupunctuur<br>Winthontlaan 200<br>3526KV Utrecht<br>Tel: 06-38393625</p>')," +
                "('<p>Beste @{FIRST_NAME},</p><p>Wij sturen u deze email om u er aan te herinneren dat u een afspraak hebt staan op @{RES_DATE} van @{RES_START_TIME} t/m @{RES_END_TIME}. Mocht u verhinderd zijn, neem dan zo snel mogelijk contact met ons op.</p><p>Hiervoor gelden de volgende regels:</p><div><ul><li>Tot 48 uur voor de afspraak is annuleren kostenloos</li><li>Binnen 48 uur voor de afspraak betaalt u 50% van de behandelkosten als annuleringskosten</li><li>Binnen 1 uur voor de afspraak betaalt u 100% van de behandelkosten als annuleringskosten</li></ul></div></p><br><p>Met vriendelijke groet,<br><br><b>Berry Prikkebeen</b><br>Prikkebeen Acupunctuur<br>Winthontlaan 200<br>3526KV Utrecht<br>Tel: 06-38393625</p>')"
            );

            migrationBuilder.Sql(
                "INSERT INTO Pages (ContentId, DisplayName, InternalName, IsEmail) VALUES " +
                "(7, 'Email nieuw account', 'Email_NewAccount', 1)," +
                "(8, 'Email reserveringsbevestiging', 'Email_ReservationConfirmation', 1)," +
                "(9, 'Email reservering annulering admin 48 uur', 'Email_ReservationCancellation_Admin_48', 1)," +
                "(10, 'Email reservering annulering admin 1 uur', 'Email_ReservationCancellation_Admin_1', 1)," +
                "(11, 'Email reservering annulering klant', 'Email_ReservationCancellation_Client', 1)," +
                "(12, 'Email reservering annulering klant 48 uur', 'Email_ReservationCancellation_Client_48', 1)," +
                "(13, 'Email reservering annulering klant 1 uur', 'Email_ReservationCancellation_Client_1', 1)," +
                "(14, 'Email reservering gemaakt door admin', 'Email_ReservationCreation_ByAdmin', 1)," +
                "(15, 'Email reservering annulering door admin', 'Email_ReservationCancellation_ByAdmin', 1)," +
                "(16, 'Email reservering herinnering', 'Email_Reminder', 1)"
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsEmail",
                table: "Pages");
        }
    }
}
