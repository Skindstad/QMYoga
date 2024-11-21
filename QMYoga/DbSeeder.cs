using Microsoft.EntityFrameworkCore;
using QMYoga.Context;
using QMYoga.Models;

namespace QMYoga;

public class DbSeeder
{
    public QMYogaContext Context { get; }
    public DbSeeder(QMYogaContext context)
    {
        Context = context;
    }

    public void InitData()
    {
        Context.Videos.ExecuteDelete();
        Context.Playlists.ExecuteDelete();
        Context.Categories.ExecuteDelete();
        Context.Tags.ExecuteDelete();

        Tag[] tags = [
            new() { Name = "Afspænding" }, // 0
            new() { Name = "Åndedræt" }, // 1
            new() { Name = "Balance" }, // 2
            new() { Name = "Blid" }, // 3
            new() { Name = "Blid Hatha" }, // 4
            new() { Name = "Dynamisk Hatha" }, // 5
            new() { Name = "Grounding" }, // 6
            new() { Name = "Hofte" }, // 7
            new() { Name = "Intens" }, // 8
            new() { Name = "Kort video" }, // 9
            new() { Name = "Lænd" }, // 10
            new() { Name = "Lang video" }, // 11
            new() { Name = "Liggende" }, // 12
            new() { Name = "Massage" }, // 13
            new() { Name = "Mellem video" }, // 14
            new() { Name = "Nakke" }, // 15
            new() { Name = "Præsentation" }, // 16
            new() { Name = "Siddende" }, // 17
            new() { Name = "Skulder" }, // 18
            new() { Name = "Stående" }, // 19
            new() { Name = "Udstyr: Blød bold" }, // 20
            new() { Name = "Udstyr: Klods" }, // 21
            new() { Name = "Udstyr: Klods eller pude" }, // 22
            new() { Name = "Udstyr: Måtte" }, // 23
            new() { Name = "Udstyr: Pølle" }, // 24
            new() { Name = "Udstyr: Stol" }, // 25
            new() { Name = "Yin" }, // 26
        ];

        Context.Tags.AddRange(tags);
        Context.SaveChanges();

        tags = Context.Tags.ToArray();

        Category[] categories = [
            new Category
            {
                Title = "Yoga",
                      SubCategories = [
                          new SubCategory
                          {
                              Title = "Blid Hatha",
                              Url = "nakke",
                              ImagePath = "images/category/blid_hatha.jpg"
                          },
                      new SubCategory
                      {
                          Title = "Dynamisk Hatha",
                          Url = "hjerte",
                          ImagePath = "images/category/dynamisk_hatha.jpg"
                      },
                      new SubCategory
                      {
                          Title = "Yin yoga",
                          Url = "ryg",
                          ImagePath = "images/category/yin.jpg"
                      },
                      new SubCategory
                      {
                          Title = "Meditation og Afspænding",
                          Url = "hjerte",
                          ImagePath = "images/category/meditation.jpg"
                      },
                      new SubCategory
                      {
                          Title = "Åndedrætsteknik",
                          Url = "hjerte",
                          ImagePath = "images/category/åndedræt.jpg"
                      }
                ]
            }
        ];

        Context.Categories.AddRange(categories);
        Context.SaveChanges();

        SubCategory[] subCategories = Context.SubCategories.ToArray();

        Playlist[] playlists = [
            new Playlist
            {
                Name = "Hoftesekvens fra online forløb",
                     Description = "Denne video er en del af et online yogaforløb og fokuserer på at skabe mobilitet, styrke og afslapning i hofterne. Sekvensen er designet til at løsne spændinger, øge fleksibiliteten og styrke musklerne omkring hofterne. Gennem blide, guidede bevægelser kombineret med dybe vejrtrækninger vil du opleve en større frihed og lethed i din krop. Perfekt til alle niveauer – fra begyndere til erfarne yogier. Find et roligt sted, rul din yogamåtte ud, og lad os starte med at tage vare på dine hofter.",
                     Date = DateTime.Now,
                     Image = "images/ryg.jpg",
                     SubCategory = subCategories[0]
            },
            new Playlist
            {
                Name = "Nakke og skuldre",
                Description = "Denne yogasekvens er skabt til at lindre spændinger og forbedre bevægeligheden i nakke og skuldre. Perfekt til dig, der sidder meget foran en skærm, oplever stivhed i overkroppen, eller ønsker at slippe daglige spændinger. Med blide stræk, mindful bevægelse og fokus på åndedrættet vil du opnå en dejlig følelse af lethed og ro i nakke- og skulderområdet. Denne sekvens er skånsom og velegnet til alle, uanset erfaring med yoga.",
                Date = DateTime.Now,
                Image = "images/nakke.jpg",
                SubCategory = subCategories[0]
            },
            new Playlist
            {
                Name = "Styrk dit fundament",
                Description = "Denne yogasekvens fokuserer på at styrke dit fundament – både fysisk og mentalt. Med en kombination af stående stillinger, balancetræning og jordforbindende bevægelser hjælper sekvensen dig med at opbygge stabilitet, styrke og grounding i kroppen. Perfekt til dig, der ønsker en solid base i din praksis, og som gerne vil forbedre din kropsbevidsthed og holdning.",
                Date = DateTime.Now,
                Image = "images/hjerte.png",
                SubCategory = subCategories[0]
            },
            new Playlist
            {
                Name = "Hofte",
                Description = "Denne playliste samler en række nøje udvalgte yogasekvenser, der fokuserer på hofternes mobilitet, fleksibilitet og styrke. Uanset om du ønsker at løsne spændinger, forbedre din bevægelighed eller finde mere grounding i din praksis, finder du her en variation af øvelser, der støtter dig. Perfekt til alle niveauer, fra nybegyndere til erfarne yogier.",
                Date = DateTime.Now,
                Image = "images/meditation.webp",
                SubCategory = subCategories[0]
            }
        ];

        Context.Playlists.AddRange(playlists);
        Context.SaveChanges();

        playlists = Context.Playlists.ToArray();

        Video[] videos = [
            new Video
            {
                Title="Hoftesekvens fra online forløb",
                     Description = "Denne video er en del af et online yogaforløb og fokuserer på at skabe mobilitet, styrke og afslapning i hofterne. Sekvensen er designet til at løsne spændinger, øge fleksibiliteten og styrke musklerne omkring hofterne. Gennem blide, guidede bevægelser kombineret med dybe vejrtrækninger vil du opleve en større frihed og lethed i din krop. Perfekt til alle niveauer – fra begyndere til erfarne yogier. Find et roligt sted, rul din yogamåtte ud, og lad os starte med at tage vare på dine hofter.",
                    Url="uploads/9938355623f45b8350bfdf785d9f23e49c1e30df1e04e608c216f71315efb7d0_program_hofte.mp4",
                    Thumbnail="images/ryg.jpg",
                    Duration=TimeSpan.FromSeconds(30),
                    UploadDate=DateTime.Now,
                    PlayList=playlists[0],
                    Tags = new int[]{11, 4, 26, 7, 10, 12, 0, 23}
                        .Select(i => tags[i])
                        .ToList()
            },
            new Video
            {
                Title = "Nakke og skuldre",
                Description = "Denne yogasekvens er skabt til at lindre spændinger og forbedre bevægeligheden i nakke og skuldre. Perfekt til dig, der sidder meget foran en skærm, oplever stivhed i overkroppen, eller ønsker at slippe daglige spændinger. Med blide stræk, mindful bevægelse og fokus på åndedrættet vil du opnå en dejlig følelse af lethed og ro i nakke- og skulderområdet. Denne sekvens er skånsom og velegnet til alle, uanset erfaring med yoga.",
                Url="uploads/47191526d581ecad04c78ae99eb2e2cfefaf6c29f6ed1aed6f39fa45e84099a8_program_nakke.mp4",
                Thumbnail="images/ryg.jpg",
                Duration=TimeSpan.FromSeconds(30),
                UploadDate=DateTime.Now,
                PlayList=playlists[1],
                    Tags = new int[]{11, 4, 15, 18, 17, 23, 21}
                        .Select(i => tags[i])
                        .ToList()
            },
            new Video
            {
                Title = "Styrk dit fundament",
                Description = "Denne yogasekvens fokuserer på at styrke dit fundament – både fysisk og mentalt. Med en kombination af stående stillinger, balancetræning og jordforbindende bevægelser hjælper sekvensen dig med at opbygge stabilitet, styrke og grounding i kroppen. Perfekt til dig, der ønsker en solid base i din praksis, og som gerne vil forbedre din kropsbevidsthed og holdning.",
                Url="uploads/995765a3fb0b305fccc91eab5e1e10b4e4f815f04e09c634e00969cb1fdc54ec_program_fundament.mp4",
                Thumbnail="images/ryg.jpg",
                Duration=TimeSpan.FromSeconds(30),
                UploadDate=DateTime.Now,
                PlayList=playlists[2],
                    Tags = new int[]{11, 5, 17, 19, 2, 6, 23}
                        .Select(i => tags[i])
                        .ToList()
            },
            new Video
            {
                Title = "Præsentation hofteøvelser",
                Description = "I denne yoga-video vil du blive guidet gennem en række effektive hofteøvelser, som hjælper med at øge fleksibiliteten, styrken og mobiliteten i hofteområdet. Øvelserne er perfekte for både begyndere og mere erfarne udøvere, og de kan hjælpe med at lindre spændinger, forbedre kropsholdningen og fremme en bedre bevægelsesfrihed. Følg med, og lær hvordan du kan arbejde med dine hofter for at skabe balance og stabilitet i hele kroppen.",
                Url = "uploads/83542792c1f27c8cc050c870d462e6536ebb0a31ea099e39e1d9763cc58e1c3d_video_1_præsentation_hofteøvelser.mp4",
                Thumbnail = "images/ryg.jpg",
                Duration = TimeSpan.FromSeconds(30),
                UploadDate = DateTime.Now,
                PlayList = playlists[3],
                    Tags = new int[] { 9, 16 }
                        .Select(i => tags[i])
                        .ToList()
            },
            new Video
            {
                Title = "Constructive rest",
                Description = "I denne video introduceres du for \"Constructive Rest\" – en simpel, men effektiv afslapningsteknik, der hjælper med at genoprette kroppens balance og reducere spændinger. Øvelsen indebærer at ligge på ryggen med benene bøjet og fødderne fladt på gulvet, hvilket giver mulighed for dyb hvile og bevidst opmærksomhed på kroppen. Denne praksis er ideel til at lindre stress, forbedre kropsholdning og fremme en følelse af ro og genopladning. Perfekt til alle, der har brug for en pause fra den travle hverdag.",
                Url="uploads/eb9fce7b352365e8c10993b323b7bb42a8043aa0a74a1954903dd0d1486ab01a_video_2_constructive_rest.mp4",
                Thumbnail="images/ryg.jpg",
                Duration=TimeSpan.FromSeconds(30),
                UploadDate=DateTime.Now,
                PlayList=playlists[3],
                    Tags = new int[]{9, 3, 7, 12, 0, 1, 23, 25, 22}
                        .Select(i => tags[i])
                        .ToList()
            },
            new Video
            {
                Title = "Brede blide sidevip med knæene",
                Description = "I denne video vil du blive guidet gennem øvelsen \"Brede blide sidevip med knæene\", en beroligende og afspændende yoga-praksis, der fokuserer på at løsne op for hofter og nedre ryg. Ved at vippe knæene fra side til side i en bred position kan du effektivt løsne spændinger og fremme en følelse af ro og balance. Øvelsen er perfekt til dem, der søger en mild måde at strække og afbalancere kroppen på, samtidig med at den hjælper med at forbedre mobiliteten i hofteregionen.",
                Url = "uploads/0e9d2a71ad60028ff59f463760951e86ff107e8dc3633f613150e6f7f0ecef2b_video_3_brede_blide_sidevip_med_knæene.mp4",
                Thumbnail = "images/ryg.jpg",
                Duration = TimeSpan.FromSeconds(30),
                UploadDate = DateTime.Now,
                PlayList = playlists[3],
                Tags = new int[] { 14, 3, 7, 26, 12, 1 }
                        .Select(i => tags[i])
                        .ToList()
            },
            new Video
            {
                Title = "Bækkentvist og bækkenrul",
                Description = "I denne video guider vi dig gennem øvelserne \"Bækkentwist\" og \"Bækkenrul\", som er fantastiske for at løsne op i rygsøjlen og bækkenområdet. Bækkentvisten hjælper med at frigøre spændinger i ryggen og forbedre rotationen, mens bækkenrulene skaber mobilitet i bækkenet og lindrer stivhed i nedre ryg. Begge øvelser er skånsomme og kan udføres af både begyndere og mere erfarne yogautøvere. De er ideelle til at opnå en bedre kropsholdning, reducere rygsmerter og fremme bevægelsesfrihed i underkroppen.",
                Url = "uploads/8caa20045e1e9234167f44d190778f47c724d811d26109ba5fc82a1f6e642396_video_4_bækkentvist_og_bækkenrul.mp4",
                Thumbnail = "images/ryg.jpg",
                Duration = TimeSpan.FromSeconds(30),
                UploadDate = DateTime.Now,
                PlayList = playlists[3],
                Tags = new int[] { 14, 4, 7, 12, 1, 26, 23, 24 }
                        .Select(i => tags[i])
                        .ToList()
            },
            new Video
            {
                Title = "Knæ på klods intenst stræk",
                Description = "I denne video bliver du introduceret til øvelsen \"Knæ på klods intenst stræk\", en effektiv og dybde-gående strækøvelse, der hjælper med at åbne hofter, lindre spændinger i lænden og forbedre fleksibiliteten. Øvelsen udføres ved at placere knæene på en forhøjet støtte (f.eks. en klods eller pude) for at intensivere strækket i hoftebøjerne og quadriceps. Dette stræk er ideelt til at arbejde med områder, der ofte er stive, og det giver en følelse af forløsning og øget bevægelsesfrihed. Perfekt for dem, der ønsker at udfordre deres fleksibilitet og få dybere stræk i underkroppen.",
                Url = "uploads/b2ac644b7661df36d31e371793a033b0c4502b8d7d9a94a34d2e9303ec62cc0a_video_5_knæ_på_klods_intenst_stræk.mp4",
                Thumbnail = "images/ryg.jpg",
                Duration = TimeSpan.FromSeconds(30),
                UploadDate = DateTime.Now,
                PlayList = playlists[3],
                Tags = new int[] { }
                        .Select(i => tags[i])
                        .ToList()
            },
            new Video
            {
                Title = "Mave liggende massage og vip fra side til side",
                Description = "I denne video bliver du guidet gennem en beroligende og afspændende øvelse, der kombinerer mave-liggende massage og vippende bevægelser fra side til side. Denne teknik er perfekt til at løsne op i rygsøjlen, afspænde musklerne i nedre ryg og forbedre blodcirkulationen. Ved at vippe fra side til side på maven stimuleres mavemusklerne og de dybe rygmuskler, hvilket skaber en blid massage, der hjælper med at lindre spændinger og fremme en følelse af velvære. Øvelsen er ideel for dem, der ønsker en skånsom måde at arbejde med ryggen og samtidig skabe en følelse af afslapning.",
                Url = "uploads/7f762d997189309bb148596eb6ba14f4d94806bd39088373c4ae2006e5045b6a_video_6_mave_liggende_massage_og_vip_fra_side_til_side.mp4",
                Thumbnail = "images/ryg.jpg",
                Duration = TimeSpan.FromSeconds(30),
                UploadDate = DateTime.Now,
                PlayList = playlists[3],
                Tags = new int[] { }
                        .Select(i => tags[i])
                        .ToList()
            },
            new Video
            {
                Title = "Direkte og indirekte massage med bold",
                Description = "I denne video lærer du teknikkerne til at udføre både direkte og indirekte massage med en bold, som hjælper med at løsne spændinger og øge blodcirkulationen i musklerne. Den direkte massage fokuserer på at trykke bolden ind mod bestemte spændte områder, mens den indirekte massage involverer blide rullende bevægelser, der stimulerer muskelafslapning og øget fleksibilitet. Denne øvelse er fantastisk til at afhjælpe muskelømhed, især i ryg, skuldre og hofter, og kan hjælpe med at reducere stress og fremme en dyb følelse af velvære. Perfekt for alle, der ønsker at forbedre deres muskulære balance og genoprette kroppens naturlige flow.",
                Url = "uploads/60cb630c4eeeb3840c7847119523897e2a86e39e333e239353f05351c8521264_video_7_direkte_og_indirekte_massage_med_bold.mp4",
                Thumbnail = "images/ryg.jpg",
                Duration = TimeSpan.FromSeconds(30),
                UploadDate = DateTime.Now,
                PlayList = playlists[3],
                Tags = new int[] { 14, 8, 12, 7, 10, 13, 23, 20 }
                        .Select(i => tags[i])
                        .ToList()
            },
            new Video
            {
                Title = "Cats tail stræk på lår og lyske med eller uden støtte",
                Description = "I denne video bliver du guidet gennem \"Cats Tail\"-strækket, en effektiv øvelse, der fokuserer på at åbne op i lår, hofter og lyske. Denne strækning er ideel til at løsne spændinger og øge fleksibiliteten i nedre del af kroppen. Øvelsen kan udføres både med og uden støtte, afhængig af din komfort og erfaring. Med støtte, som en pude eller blok, kan du få ekstra hjælp til at opnå dybere stræk, mens den uden støtte udfordrer din balance og styrke. \"Cats Tail\" er perfekt til at fremme mobilitet, reducere stivhed og hjælpe med at forbedre kropsholdningen.",
                Url = "uploads/102e100ac421f8743a9dd5e0e0a0fa263e9d2e7e119c9c6c8796b52cf9111ab5_video_9_cats_tail_stræk_på_lår_og_lyske_med_eller_uden_støtte.mp4",
                Thumbnail = "images/ryg.jpg",
                Duration = TimeSpan.FromSeconds(30),
                UploadDate = DateTime.Now,
                PlayList = playlists[3],
                Tags = new int[] { }
                        .Select(i => tags[i])
                        .ToList()
            },
            new Video
            {
                Title = "Siddende foroverbøjning",
                Description = "I denne video lærer du, hvordan du udfører den siddende foroverbøjning, en beroligende og dybde-gående strækøvelse, der hjælper med at åbne op i ryggen, hofterne og hamstrings. Øvelsen styrker samtidig fleksibiliteten i benene og fremmer en afslappende strækning af hele rygsøjlen. Ved at bøje fremad i hoften, mens du holder ryggen lang og brystet åbent, kan du også arbejde med at reducere spændinger i nedre ryg og forbedre kropsholdningen. Denne øvelse er ideel til alle niveauer og kan tilpasses med variationer for at imødekomme dine behov.",
                Url = "uploads/eb288ad30ebd1c89bfe1b0bbd3e176af57b48d3b125438df1e4083e43d21c991_video_10_siddende_foroverbøjning.mp4",
                Thumbnail = "images/ryg.jpg",
                Duration = TimeSpan.FromSeconds(30),
                UploadDate = DateTime.Now,
                PlayList = playlists[3],
                Tags = new int[] { }
                        .Select(i => tags[i])
                        .ToList()
            },
            new Video
            {
                Title = "Afspænding",
                Description = "I denne video guides du gennem en dyb afspændingsteknik, som hjælper med at frigive spændinger og skabe indre ro. Øvelsen er designet til at berolige sindet, lindre stress og fremme en følelse af total afslapning i både krop og sind. Ved at fokusere på åndedræt, kropsbevidsthed og bevidst afslapning af muskelgrupper, giver denne praksis dig mulighed for at komme helt ned i gear og genoplade efter en lang dag. Afspænding er en ideel metode til at reducere stress, forbedre søvn og øge dit generelle velvære.",
                Url = "uploads/26027b81a15e285c8310a069b74098c811ce873f7a04df31805ac9ba64551caf_video_11_afspænding.mp4",
                Thumbnail = "images/ryg.jpg",
                Duration = TimeSpan.FromSeconds(30),
                UploadDate = DateTime.Now,
                PlayList = playlists[3],
                Tags = new int[] { }
                        .Select(i => tags[i])
                        .ToList()
            },
            ];

        Context.Videos.AddRange(videos);
        Context.SaveChanges();
    }
}
