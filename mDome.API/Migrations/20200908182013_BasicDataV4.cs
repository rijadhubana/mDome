using Microsoft.EntityFrameworkCore.Migrations;

namespace mDome.API.Migrations
{
    public partial class BasicDataV4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Album",
                keyColumn: "AlbumId",
                keyValue: 1,
                column: "AlbumGeneratedRating",
                value: 4.7999999999999998);

            migrationBuilder.UpdateData(
                table: "Album",
                keyColumn: "AlbumId",
                keyValue: 3,
                column: "AlbumGeneratedRating",
                value: 5.0);

            migrationBuilder.InsertData(
                table: "Track",
                columns: new[] { "TrackId", "AlbumId", "TrackLyrics", "TrackName", "TrackNumber", "TrackViews", "TrackYoutubeId" },
                values: new object[,]
                {
                    { 25, 3, @"(D'you think the end of the world is coming?)
                The preacher man says it's the end of time
                He says that America's rivers are going dry
                The interest is up, the stock market's down
                You guys have to be careful walking around here this late at night
                (Spare change?)
                This, no we don't ma'am, I'm sorry, this this this is the perfect place to get jumped
                (But d'you think the end of the world is coming?)
                No, so says the preacher man but I don't go by what he says
                (Indeed)

                Where are you going?
                Where are you going?

                Where are you going?
                Where are you going?
                Where are you going?

                Where are you going, going?
                Where are you going?
                Where are you going?
                Where are you going? (Where are you going?)

                Where are you going?
                Where are you going?
                Where are you going?

                Where are you going?
                Where are you going?
                Where are you going?
                Where are you going?

                Where are you going?

                Where are you going?", "Providence", 3, 0, "6tZ_uwDlmPY" },
                    { 24, 3, @"...Nothing's Alrite in Our Life.../The Dead Flag Blues (Reprise)

                Instrumental

                The Sad Mafioso...

                Instrumental

                Drugs in Tokyo/Black Helicopter

                They have a large barge with a radio antenna tower on it that they would charge up and discharge
                They have a large barge with a radio antenna tower on it that they would charge up and discharge
                They have a large barge with a radio antenna tower on it", "East Hastings", 2, 0, "V9Ty3YnWN80" },
                    { 23, 3, @"The car is on fire, and there's no driver at the wheel
                And the sewers are all muddied with a thousand lonely suicides and a dark wind blows

                The government is corrupt
                And we're on so many drugs with the radio on and the curtains drawn

                We're trapped in the belly of this horrible machine
                And the machine is bleeding to death

                The sun has fallen down
                And the billboards are all leering
                And the flags are all dead at the top of their poles

                It went like this

                The buildings tumbled in on themselves
                Mothers clutching babies
                Picked through the rubble and pulled out their hair

                The skyline was beautiful on fire
                All twisted metal stretching upwards
                Everything washed in a thin orange haze

                I said, ""Kiss me, you're beautiful, these are truly the last days""
                You grabbed my hand and we fell into it
                Like a daydream or a fever

                We woke up one morning and fell a little further down
                For sure it's the valley of death
                I open up my wallet and it's full of blood", "The Dead Flag Blues", 1, 1, "XVekJTmtwqM" },
                    { 22, 1, @"I've lived my life to stand in the shadow of your heart
                You make my dreams complete and then crash them down
                But every dream could breathe new life
                Just like the memories you had with me
                I want to take you down but now you want me dead
                The way you lie sends an arrow straight into my heart
                You make my dreams complete and then crash them down
                But every dream can breathe new life
                Maybe that's just in my head
                I want to take you down but now you want me dead

                You want me back but I don't care
                I want you back but you're not there

                I've lived my life to stand in the shadow of your heart
                You make my dreams complete and then crash them down
                But every dream could bring new life
                But the close you had with me
                I want to take you down but now you want me dead

                You want me back but I don't care
                I want you back but you're not there", "I Lived My Life To Stand In The Shadow Of Your Heart", 10, 1, "cT8qJi-oad0" },
                    { 8, 1, @"Waves wash over everything on the ground
                The sun's reflection blocked by a sound
                The sound of life just as it's ripped apart
                I'd say these words to you but fear that my heart would stay away
                You took my hand, so I showed you the place
                Now it's grown empty you can see it in my face
                Then the sound and it rips me in half
                Who'd say these things to you if it wasn't meant to last not today

                Love, love, love, love, love, love, love, love

                What comes out nails your head to the floor
                I say I'm sorry as I'm walking out the door

                Love, love, love, love, love, love, love, love", "Everything Always Goes Wrong", 8, 0, "B4VcecIeEFA" },
                    { 9, 1, @"People living in the dark
                State protecting life then tear it apart
                'Cause commotion cause a scene, cracking skull, expanding seam
                Every time there is a choice, it's tear it apart

                Fall, high, don't ever touch the ground
                Know, no wars are ever won
                When they can't kill me then know that it's safe
                To come back, come back, come back exploding head
                Exploding head, exploding head, exploding head

                Touch by the hand of god
                It's a secret that is held now fire the gun
                Sit down love and tighten up the pace
                Commands close eyes, command shoot off the face

                Fall, high, don't ever touch the ground
                Know, no wars are ever won
                When they can't kill me then know that it's safe
                To come back, come back, come back exploding head
                Exploding head, exploding head, exploding head

                Lovers bound by their tongues
                Bound by their hands, bound by love
                Intentions, shadow truth and the motivation's done
                The secret was a lie and the truth was never won

                Fall, high, don't ever touch the ground
                Know, no wars are ever won
                When they can't kill me then know that it's safe
                To come back, come back, come back exploding head
                Exploding head, exploding head, exploding head
                Exploding head, exploding head, exploding head, exploding head", "Exploding Head", 9, 0, "aiea07gW8VI" },
                    { 6, 1, @"Leaving life with a hand to hold
                And I don't wanna go back
                We couldn't see cause our shades were on so we lift
                And our ego's dead
                And you were trapped in a ten foot scream
                Blue stars float on a plastic screen
                Give me something to feel all right
                'Cause it's acid to my head, so come on
                50 miles of desert sky
                And you were getting me off
                We couldn't talk so we sewed our words to our shirts
                Where we sewed our heads
                Master feelers on light globe beams
                People move and shake like trees
                Give me something to feel all right
                'Cause it's acid to my head, so come on, so come on
                So come on, so come on

                And you'll kick me in the head, I'm alive and I'm dead
                And the colors shift like a fifty forture wall, common fuck
                Don't kill you've been alone, stuck sick and miles from home
                And the forture grips as you lose control

                Engines revved and your eyes are a night
                And you were getting me high
                We couldn't love 'cause we break our hearts
                On the words where we sewed our hearts
                And you been talking behind my back
                And you've been talking inside my back
                Give me something to feel all right
                'Cause it's acid to my head, so come on, so come on
                So come on, so come on

                And you'll kick me in the head, I'm alive and I'm dead
                And the colors shift like a fifty forture wall, common fuck
                Don't kill you've been alone, stuck sick and miles from home
                And it's acid that makes you lose, gimme acid, gimme acid, gimme acid", "Ego Death", 6, 0, "oGu8i6EwcPU" },
                    { 5, 1, @"I sit here waiting as time keeps slipping away
                In my heart are all the words that I want to say
                Without you I know that I, I would die
                And with you I know my heart would always try

                You have my heart, you have my soul
                True love, it should last forever
                Time's slipping away

                I can't shut up my mouth I have to say how I feel
                'Cause when I can't control my heart I know that it's real
                I hold on tight and try to convince you to stay
                And have my heart tell you what I've been dying to say

                You have my heart, you have my soul
                True love, it should last forever
                Time's slipping away

                My mind's made up and I know that I want you
                Because these words and feeling of love are all true
                I'll never say it but I always want you to know
                As each day goes by my love continues to grow

                You have my heart, you have my soul
                True love, it should last forever, forever
                You don't remember me, you don't remember me
                You don't remember me, you don't remember me

                I sit here waiting as the years keep slipping away
                In my heart were all of the words that I wanted to say
                I didn't get the chance to show my feelings were real
                And my heart would never tell you just how I feel
                My hopes and dreams are crushed and have washed away
                Leaving my heart empty and without a word to say
                My hopes and dreams are crushed and have slipped away
                My hopes and dreams are crushed and all washed away
                My hopes and dreams are crushed and have slipped away", "Keep Slipping Away", 5, 3, "hUdntXPEEgM" },
                    { 4, 1, @"Oh, hear the sound on the tracks and on the run
                Now, now you're down, stupid shit, you better run

                What, what the fuck, don't play with my heart
                I said what, what the fuck, don't play with my heart, who am I?

                Dream but dream alone, driving fast and driving thin
                Dream and dream you're home, live in fast and live in sin

                What, what the fuck, don't play with my heart
                I said what, what the fuck, don't play with my heart, who am I?

                You're all alone, now you're all alone
                Now you're all alone again
                I said you're fucked up, girl, you won't come down
                Don't take me down, now you're all alone again

                Down, I let you in, holding love and hold it in
                Feeling bad and looking thin, holding on and holding in

                What, what the fuck, don't play with my heart
                I said what, what the fuck, don't play with my heart, who am I?", "Deadbeat", 4, 0, "_p5us-dKiIo" },
                    { 3, 1, @"If love could be the answer then the answer would be you
                And if I could have a feeling then I'd want it to be true
                My dreams have all been broken and my past is flood with tears
                Now my time is open but the feelings gone, the feeling is gone
                I hold on to a reason but I've got no reason to
                Try and try forever but I won't get back to you
                And I'm dying to meet you, and I'm dying to see you
                I'm dying to hold you and I'm dying to have you
                I can try to make you stay but the feelings gone, the feeling has gone

                Now I build up strength and I build it up to
                Cut away the answer and I hope I get to you
                Well I'm dying to meet you, I'm dying to see you
                I'm dying to hold you and I'm dying to have you
                Some things never go away but the feelings gone, the feeling is gone", "Lost Feeling", 3, 0, "NOIS6j-nG7Y" },
                    { 2, 1, @"Don't say that you're nice to me alright, you're lying
                Don't say that you'll be with me tonight, you're lying
                Don't think I forgot what you said implying
                There's nothing there and it's dead

                In your heart, in your heart, in your heart, in your heart

                Don't say I'm not nice to you tonight, I'm trying
                Don't say I'm not in love with you alright, I'm crying
                Don't say that you'll be with me again, you're lying
                There's nothing there and it's dead

                In your heart, in your heart, in your heart, in your heart

                In your heart, in your heart, in your heart, in your heart
                In your heart, in your heart, in your heart, in your heart", "In Your Heart", 2, 5, "j6YKGJToe9w" },
                    { 7, 1, @"I'm a little child, smile when you smile
                Joy when you're around and sad when you are down
                'Cause I found love I want you next to me
                And I found life with you here

                You make life warm, you make me happy when you
                Tell me everything will be okay, hey
                Let's make love, you make me happy now but
                You can see my heart change with the sun
                Now I'm feeling sad, so I want you, I want you
                I still want you, I want you, I still want you

                You won't talk to me and I can't make you smile
                I just bring you down and you don't want me here
                Though I still feel love and want you next to me
                'Cause I feel life when you're around

                We made life warm, we were so happy then but
                You won't tell me everything's okay, hey
                We had love and I want it all again but
                I can see your heart change with the sun
                Even though you're done I still want you, I want you
                I still want you, I want you, I still want you

                I want you, I still want you, I want you, I still want you
                I want you, I still want you, I still want you, I still want you
                I still want you, I still want you, I want you, I still want you", "Smile When You Smile", 7, 3, "P2G6K7gKdMc" },
                    { 1, 1, @"Oh no, don't feel it's right, fall apart, let's not fight
                Make up, stay tonight, feel alone, it's alright

                It is nothing, it is nothing, it is nothing

                Hope lust life what went wrong, see now it's all gone
                No-no, don't hold on, feel good what went wrong

                It is nothing, it is nothing, it is nothing

                Oh no, don't feel it's right, fall apart, let's not fight
                Make up, stay tonight, feel alone, it's alright

                It is nothing, it is nothing, it is nothing
                It is nothing, it is nothing, it is nothing
                It is nothing, it is nothing", "It Is Nothing", 1, 10, "sNTReqI_PdA" }
                });

            migrationBuilder.UpdateData(
                table: "UserProfile",
                keyColumn: "UserId",
                keyValue: 7,
                column: "SuspendedFlag",
                value: false);

            migrationBuilder.UpdateData(
                table: "UserProfile",
                keyColumn: "UserId",
                keyValue: 8,
                column: "SuspendedFlag",
                value: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Track",
                keyColumn: "TrackId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Track",
                keyColumn: "TrackId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Track",
                keyColumn: "TrackId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Track",
                keyColumn: "TrackId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Track",
                keyColumn: "TrackId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Track",
                keyColumn: "TrackId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Track",
                keyColumn: "TrackId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Track",
                keyColumn: "TrackId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Track",
                keyColumn: "TrackId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Track",
                keyColumn: "TrackId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Track",
                keyColumn: "TrackId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Track",
                keyColumn: "TrackId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Track",
                keyColumn: "TrackId",
                keyValue: 25);

            migrationBuilder.UpdateData(
                table: "Album",
                keyColumn: "AlbumId",
                keyValue: 1,
                column: "AlbumGeneratedRating",
                value: 4.7999999999999998);

            migrationBuilder.UpdateData(
                table: "Album",
                keyColumn: "AlbumId",
                keyValue: 3,
                column: "AlbumGeneratedRating",
                value: 5.0);

            migrationBuilder.UpdateData(
                table: "UserProfile",
                keyColumn: "UserId",
                keyValue: 7,
                column: "SuspendedFlag",
                value: false);

            migrationBuilder.UpdateData(
                table: "UserProfile",
                keyColumn: "UserId",
                keyValue: 8,
                column: "SuspendedFlag",
                value: false);
        }
    }
}
