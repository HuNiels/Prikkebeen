using Microsoft.EntityFrameworkCore.Migrations;

namespace Acupunctuur.Migrations {
    public partial class Initial : Migration {
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.CreateTable(
                name: "Contents",
                columns: table => new {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RawHtml = table.Column<string>(nullable: true)
                },
                constraints: table => {
                    table.PrimaryKey("PK_Contents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileData = table.Column<byte[]>(nullable: true),
                    FileMimeType = table.Column<string>(nullable: true)
                },
                constraints: table => {
                    table.PrimaryKey("PK_Files", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pages",
                columns: table => new {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InternalName = table.Column<string>(nullable: true),
                    DisplayName = table.Column<string>(nullable: true),
                    ContentId = table.Column<int>(nullable: true)
                },
                constraints: table => {
                    table.PrimaryKey("PK_Pages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pages_Contents_ContentId",
                        column: x => x.ContentId,
                        principalTable: "Contents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pages_ContentId",
                table: "Pages",
                column: "ContentId");

            migrationBuilder.Sql(
                "INSERT INTO Contents (RawHtml) VALUES " +
                "('<h2 class=''display-4 text-center''>Acupunctuur en energiebanen</h2><div class=''mx-auto w-50''><p style=''text-align: center;''>Beeld je eens in dat je een grote akker ziet. En stel je eens voor dat een netwerk van allerlei waterstroompjes die de akker voorziet van voeding. En dan ineens is er in één stroompje een verstopping. Wat gebeurt er dan? Het water komt niet meer voorbij de verstopping en daardoor mist een deel van de akker voeding. Het gedeelte na de blokkade droogt misschien op en lijdt eronder. En vlak voor de verstopping hoopt het water op en stroomt het deels terug, de verkeerde kant op. Mogelijk overstroomt het deel voor de verstopping en krijgt te veel water.</p><p style=''text-align: center;''>In ons lichaam bestaat ook een netwerk waar van alles doorheen stroomt. Energie (Qi), bloed, vloeistoffen, prikkels. Dit netwerk heeft onderling ook communicatie met de diverse orgaansystemen. Er is interactie. Zo weet je als je een droge mond krijgt dat je moet drinken. En als je spieren harder gaan werken gaat je hart sneller kloppen, het bloed vlugger rond en je ademhaling wordt ook sneller. Als iemand je ineens knijpt, roep je wellicht ‘auw!’ en mogelijk voel je vervolgens boosheid. Afijn, zo zijn er allerlei verbindingen binnen dat complexe netwerk. Er is communicatie onderling binnen dat netwerk. Het een beïnvloedt het ander.</p><p style=''text-align: center;''>Acupunctuur reguleert deze communicatie, de balans en samenwerking tussen al die systemen. Enerzijds zorgt dat voor een soepel verloop van alle voorzieningen zodat ‘de akker’ (uw lichaam) voldoende gevoed wordt. Anderzijds lost het blokkades op die op hun beurt zorgen voor leegte (ondervoeding) of volte (ophoping en overstroming).</p><p style=''text-align: center;''>Er is overigens meer dan alleen de fysieke regulering van het netwerk zoals hierboven beschreven. Lichaam en geest beïnvloeden elkaar natuurlijk ook. Heb je bijvoorbeeld honger, dan verandert je gemoedstoestand. Mogelijk wordt je een beetje kriegel? En als je stress hebt, kun je misschien niet eten, of je eet juist te veel om een goed gevoel te krijgen. Het is duidelijk dat lichaam en geest elkaar beïnvloeden. Acupunctuur werkt ook om de samenwerking en balans tussen geest en lichaam te bevorderen.</p><p style=''text-align: center;''>Acupunctuur is daarmee een methode die werkt aan de basis van gezondheid. Het heeft geen nevenverschijnselen zoals vaak bij medicijnen het geval is. Het kan symptomen bestrijden maar werkt vooral aan het herstellen en verbeteren van de werking van het complexe netwerk waardoor het lichaam én de geest weer beter gaat functioneren.</p></div>')," +
                "('<h2 class=''display-4 text-center''>Waarmee kan Acupunctuur u helpen? En waardoor werkt het?</h2><div class=''mx-auto w-50''><p>Acupunctuur kan helpen bij het verlichten of geheel wegnemen van pijn en ongemak. Dit komt omdat door acupunctuur blokkades kunnen worden weggenomen die de oorzaak zijn van deze klachten.Blokkades kunnen leiden tot leegte achter de blokkade of het overvol ‘lopen’ (ophopen) voor de blokkade. Zowel leegte als volte kan tot pijn en ongemak leiden. Bijvoorbeeld bij maagklachten, diarree, constipatie, hoofdpijnen, spierklachten, rugklachten, schouderklachten, elleboogklachten, PMS e.d.</p><p>Acupunctuur kan helpen bij het creëren van rust van uw lichaam en geest waardoor u zich prettiger gaat voelen.Dit komt omdat door acupunctuur de balans in uw ‘systeem’ (lichaam – geest) wordt verbeterd.Onevenredige energiestromen kunnen enerzijds leiden tot tekorten en anderzijds tot overmatige werking, wat kan leiden tot klachten.Ook kan energie te veel ‘omhoog stromen’ waardoor energie in uw hoofd ophoopt met onder andere hoofdpijn en duizeligheid tot gevolg. (Voorbeelden van klachten: stress, depressie, burn out, woedeaanvallen, te veel nadenken, hoofdpijn)</p><p>Acupunctuur kan u helpen om beter te weten wat u wilt. Dit komt omdat door acupunctuur de afstemming met uw bronenergie kan worden versterkt.Daardoor komt u dichter ‘bij uzelf’ en krijgt u meer zelfvertrouwen, zelfwaardering en eigenheid. Acupunctuur kan u helpen als u niet goed weet wat u wilt, moeilijk beslissingen kunt maken, een beetje het gevoel heeft uzelf kwijt te zijn, beter voor uzelf wilt kunnen opkomen e.d.</p><p>Acupunctuur kan u helpen om meer energie te krijgen. Dit komt omdat door acupunctuur een betere geleiding en afstemming op uw energiebronnen kan worden gemaakt.En omdat onbalans en blokkades kunnen worden weggenomen. ‘Energielekken’ verminderen en ‘aansluitingen’ verbeteren. Denk bijvoorbeeld aan chronische vermoeidheid.</p><p>Acupunctuur kan helpen om huidproblemen te verminderen of weg te nemen, zoals eczeem, jeuk, allergie.Dit komt omdat door acupunctuur de kwaliteit en temperatuur in uw bloed en vochthuishouding kan worden verbeterd.Vaak ligt daar de aanleiding van deze klachten.</p></div>')," +
                "('<h2 class=''display-4 text-center''>Hoe verloopt een sessie?</h2><div class=''mx-auto w-50''><p>Filmpjes; later geluid eronder zetten.</p><ul><li>Filmpje online reserveren.</li><li>Filmpje binnenkomst. (Parkeren, deur openen, ontvangst, blik in ruimte)</li><li>Filmpje diagnose. (Gesprek, pols, tong, palpatie, bloeddruk)</li><li>Filmpje ontkleden en plaatsnemen onder handdoek.</li><li>Filmpje naald zetten.Buigzaam, wegwerp, hygiëne, soorten / lengtes, duwen met vinger, contact patiënt, pop / kaart met 365 punten.</li><li>Filmpje oor-acupunctuur; naald, kleine naald, zaadje.</li><li>Filmpje stroom.</li><li>Filmpje cupping en moving cupping. (foto resultaat na cupping)</li><li>Filmpje moxibustion.Op naald, op gember, met stick. TDP lamp.</li><li>Filmpje FSN.</li></ul><p>Indien met foto’s; hieronder de teksten:</p><ul><li>Foto online reserveren.</li><li>Foto binnenkomst. (Parkeren, deur openen, ontvangst, blik in ruimte)</li><li>Foto diagnose. (Gesprek, pols, tong, palpatie, bloeddruk)</li><li>Foto ontkleden en plaatsnemen onder handdoek.</li><li>Foto naald zetten.Buigzaam, wegwerp, hygiëne, soorten / lengtes, duwen met vinger, contact patiënt, pop / kaart met 365 punten.</li><li>Foto oor-acupunctuur; naald, kleine naald, zaadje.</li><li>Foto stroom.</li><li>Foto cupping en moving cupping. (foto resultaat na cupping)</li><li>Foto moxibustion.Op naald, op gember, met stick. TDP lamp.</li><li>Foto FSN.</li></ul></div>')," +
                "('<h2 class=''display-4 text-center''>Vakbekwaamheid</h2><div class=''mx-auto w-50''><p>Diploma’s en certificaten:</p><p>Medische Basis Kennis</p><p>EHBO</p><p>TCM basiskennis en Acupunctuur specialisatie</p><p>Licentiecertificaat beroepsvereniging Zhong</p><p>5 spirits, I ching</p><p>FSN (Onderhuidse methode van behandeling, werkt direct bij klachten vanuit verkrampingen in spieren.</p><p>Balance methode, een methode waarbij je op andere plaatsen behandeld dan waar de pijn zit.</p><p>Foto’s met doktoren van school, link naar Shenzhou, en Cai Hong?</p><p>Foto’s Tai Chi, Qi Gong en Wing Tjun.</p><p>Persoonlijke interesse voor psycho-emotionele steun.</p><p>Al jarenlang behandel en steun ik jong en oud die op psychisch, emotioneel of spiritueel gebied begeleiding kunnen gebruiken. Daarbij kan ik naar behoefte allerlei interventies inzetten zoals:</p><ul><li>reguliere coachtechnieken (Gecertificeerde coach en onderwijs ook coachtechnieken)</li><li>positieve psychologie oefeningen (Gecertificeerd door Dr.Barbara Fredrickson in Positieve psychologie)</li><li>Shamballa Multi Dimensional Healing (Op alle niveaus gecertificeerd)</li><li>Enneagram Integratie Kunde(Bevoegd trainer en coach)</li><li>Emotional Freedom Technieken</li><li>Lichaamsgericht werk</li></ul><p>Acupunctuur sluit daarbij geweldig aan daar je met acupunctuur balans en afstemming kunt vergroten naar zowel je eigen kern of bron als ook naar je omgeving. Je kunt bijvoorbeeld middels naaldzettingen meer zelfvertrouwen en veiligheid gaan ervaren. Beter weten ‘wie je bent en wat je wilt’. Of beter beslissingen kunnen maken. En ook meer wilskracht krijgen. Gemakkelijker expressie geven en dus jezelf tonen, wat positief werkt binnen relaties met anderen. In de specifieke toepassingen op het psychische-, emotionele- en spirituele gebied ben ik zeer geïnteresseerd. Het is dan ook mijn doel om me daarin steeds  verder te blijven specialiseren.</p><p>Qi Gong, Tai Chi en Wing Tjun Kung Fu (Foto’s)</p><p>Al jaren verzorg ik lessen op dit gebied en de achterliggende kennis en inzichten zet ik weer in tijdens de behandelingen.</p></div>')," +
                "('<h2 class=''display-4 text-center''>Contactgegevens</h2><div class=''mx-auto w-50''><p>Prikkebeen Acupunctuur</p><p>Winthontlaan 200</p><p>3526 KV Utrecht</p><p><a href = ''mailto:info@prikkebeen-consultancy.nl'' >info@prikkebeen-consultancy.nl</a></p><p>06-38393625</p><p>(Prikkebeen Acupunctuur valt fiscaal onder het bedrijf Prikkebeen Consultancy)</p></div>')," +
                "('<h2 class=''display-4 text-center''>Privacyverklaring Wet AVG</h2><div class=''mx-auto w-50''><p>Privacyverklaring aangaande de bescherming van uw persoonsgegevens.</p><p>Allereerst is discretie van uiterst belang. Zeker in een dorp waar iedereen elkaar kent. Daar ben ik me uiteraard zeer bewust van. Geen informatie zal zonder toestemming naar buiten worden gebracht!</p><h4>‘Privacy by design’</h4><p>Verder zal Acupunctuur Prikkebeen alléén de hoognodige informatie online opslaan. Informatie om u bijvoorbeeld te kunnen terugbellen als het nodig is om een afspraak te verzetten of te cancelen in een noodgeval. Dus uw naam, telefoonnummer, emailadres en adres zijn wenselijk. Andere noodzakelijke informatie is datgene wat verplicht op een factuur dient te worden vermeldt. Zoals uw BSN en polisnummer.</p><h4>Uw medische gegevens</h4><p>In het eerste consult wordt een diagnose gedaan. Deze mond uit in volgens de TCM (Traditionele Chinese Geneeskunde) geldende ‘patronen, behandelprincipes en puntcombinaties’. Om te kunnen teruglezen welke behandeling u in voorafgaande sessies heeft gehad zal deze informatie worden opgeslagen op een EXTERNE HARDE SCHIJF. U kunt deze data te allen tijde inzien en verkrijgen. (Data portabiliteit: dit wil zeggen dat data voorhanden zijn om bijvoorbeeld na instemming van u aan een arts, fysiotherapeut of andere professional  door te geven)</p><h4>Bescherming online</h4><p>De PC waarop wordt gewerkt is beschermd door ESET NOD23 Antivirus en wordt voortdurend ge-update. Gegevens worden direct en alleen overgeschreven naar een externe harde schijf welke steeds nadien word losgekoppeld van de PC. De kans dat er data worden gevonden welke zijn gekoppeld aan uw naam zijn daardoor zeer gering. Ook de facturering zal op de externe harde schijf worden opgeslagen.</p><h4>Gegevensverwerking en register</h4><p>De enige gegevens die worden verwerkt zijn de directe notities van een sessie en de facturering.</p><h4>‘Privacy by default’</h4><p>Er komen géén nieuwsbrieven uit. Er wordt géén onnodige informatie gevraagd of opgeslagen. Deze informatie betreffende AVG staat op de website zodat men kennis kan nemen van deze informatie en vertrouwen krijgt in de wijze waarop Prikkebeen Acupunctuur met privé gegevens om gaat.</p><p>Aangezien het verplicht is om dit te vermelden in een privacyverklaring: uiteraard speelt of verkoopt Prikkebeen Acupunctuur geen gegevens door!</p><p>Link met informatie betreffende AVG.<a href = ''https://autoriteitpersoonsgegevens.nl/nl/onderwerpen/avg-europese-privacywetgeving/algemene-informatie-avg'' > https://autoriteitpersoonsgegevens.nl/nl/onderwerpen/avg-europese-privacywetgeving/algemene-informatie-avg</a></p><p>Hopende u voldoende te hebben geïnformeerd zie ik u graag tegemoet in de praktijk van Prikkebeen Acupunctuur.</p></div>')"
            );

            migrationBuilder.Sql(
                "INSERT INTO Pages (ContentId, DisplayName, InternalName) VALUES " +
                "(1, 'Informatie', 'Info')," +
                "(2, 'Voordelen', 'Benefits')," +
                "(3, 'Behandeling', 'Treatment')," +
                "(4, 'Vakbekwaamheid', 'Certifications')," +
                "(5, 'Contact', 'Contact')," +
                "(6, 'Privacyverklaring', 'Privacy')"
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "Pages");

            migrationBuilder.DropTable(
                name: "Contents");
        }
    }
}
