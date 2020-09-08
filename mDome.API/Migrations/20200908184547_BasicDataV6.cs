using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace mDome.API.Migrations
{
    public partial class BasicDataV6 : Migration
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
                table: "AlbumList",
                columns: new[] { "AlbumListId", "AlbumListDescription", "AlbumListName", "AlbumListType", "ListDateCreated", "UniqueKey", "UserId" },
                values: new object[,]
                {
                    { 8, "", "Liked Albums", "Private", new DateTime(2020, 8, 27, 19, 1, 42, 10, DateTimeKind.Unspecified), "+JRFlS5pD0uKJwh+EM", 7 },
                    { 10, "", "Liked Albums", "Private", new DateTime(2020, 9, 7, 10, 44, 52, 893, DateTimeKind.Unspecified), "k3w7JVyq3U+5bZbNwk", 8 }
                });

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "PostId",
                keyValue: 3,
                column: "IsGlobal",
                value: true);

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "PostId",
                keyValue: 11,
                column: "IsGlobal",
                value: false);

            migrationBuilder.UpdateData(
                table: "Track",
                keyColumn: "TrackId",
                keyValue: 1,
                columns: new[] { "TrackLyrics", "TrackViews" },
                values: new object[] { @"Oh no, don't feel it's right, fall apart, let's not fight
Make up, stay tonight, feel alone, it's alright

It is nothing, it is nothing, it is nothing

Hope lust life what went wrong, see now it's all gone
No-no, don't hold on, feel good what went wrong

It is nothing, it is nothing, it is nothing

Oh no, don't feel it's right, fall apart, let's not fight
Make up, stay tonight, feel alone, it's alright

It is nothing, it is nothing, it is nothing
It is nothing, it is nothing, it is nothing
It is nothing, it is nothing", 10 });

            migrationBuilder.UpdateData(
                table: "Track",
                keyColumn: "TrackId",
                keyValue: 2,
                columns: new[] { "TrackLyrics", "TrackViews" },
                values: new object[] { @"Don't say that you're nice to me alright, you're lying
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
In your heart, in your heart, in your heart, in your heart", 5 });

            migrationBuilder.UpdateData(
                table: "Track",
                keyColumn: "TrackId",
                keyValue: 3,
                columns: new[] { "TrackLyrics", "TrackViews" },
                values: new object[] { @"If love could be the answer then the answer would be you
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
Some things never go away but the feelings gone, the feeling is gone", 0 });

            migrationBuilder.UpdateData(
                table: "Track",
                keyColumn: "TrackId",
                keyValue: 4,
                columns: new[] { "TrackLyrics", "TrackViews" },
                values: new object[] { @"Oh, hear the sound on the tracks and on the run
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
I said what, what the fuck, don't play with my heart, who am I?", 0 });

            migrationBuilder.UpdateData(
                table: "Track",
                keyColumn: "TrackId",
                keyValue: 5,
                columns: new[] { "TrackLyrics", "TrackViews" },
                values: new object[] { @"I sit here waiting as time keeps slipping away
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
My hopes and dreams are crushed and have slipped away", 3 });

            migrationBuilder.UpdateData(
                table: "Track",
                keyColumn: "TrackId",
                keyValue: 6,
                columns: new[] { "TrackLyrics", "TrackViews" },
                values: new object[] { @"Leaving life with a hand to hold
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
And it's acid that makes you lose, gimme acid, gimme acid, gimme acid", 0 });

            migrationBuilder.UpdateData(
                table: "Track",
                keyColumn: "TrackId",
                keyValue: 7,
                columns: new[] { "TrackLyrics", "TrackViews" },
                values: new object[] { @"I'm a little child, smile when you smile
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
I still want you, I still want you, I want you, I still want you", 3 });

            migrationBuilder.UpdateData(
                table: "Track",
                keyColumn: "TrackId",
                keyValue: 8,
                columns: new[] { "TrackLyrics", "TrackViews" },
                values: new object[] { @"Waves wash over everything on the ground
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

Love, love, love, love, love, love, love, love", 0 });

            migrationBuilder.UpdateData(
                table: "Track",
                keyColumn: "TrackId",
                keyValue: 9,
                columns: new[] { "TrackLyrics", "TrackViews" },
                values: new object[] { @"People living in the dark
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
Exploding head, exploding head, exploding head, exploding head", 0 });

            migrationBuilder.UpdateData(
                table: "Track",
                keyColumn: "TrackId",
                keyValue: 22,
                columns: new[] { "TrackLyrics", "TrackViews" },
                values: new object[] { @"I've lived my life to stand in the shadow of your heart
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
I want you back but you're not there", 1 });

            migrationBuilder.UpdateData(
                table: "Track",
                keyColumn: "TrackId",
                keyValue: 23,
                columns: new[] { "TrackLyrics", "TrackViews" },
                values: new object[] { @"The car is on fire, and there's no driver at the wheel
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
I open up my wallet and it's full of blood", 1 });

            migrationBuilder.UpdateData(
                table: "Track",
                keyColumn: "TrackId",
                keyValue: 24,
                columns: new[] { "TrackLyrics", "TrackViews" },
                values: new object[] { @"...Nothing's Alrite in Our Life.../The Dead Flag Blues (Reprise)

Instrumental

The Sad Mafioso...

Instrumental

Drugs in Tokyo/Black Helicopter

They have a large barge with a radio antenna tower on it that they would charge up and discharge
They have a large barge with a radio antenna tower on it that they would charge up and discharge
They have a large barge with a radio antenna tower on it", 0 });

            migrationBuilder.UpdateData(
                table: "Track",
                keyColumn: "TrackId",
                keyValue: 25,
                columns: new[] { "TrackLyrics", "TrackViews" },
                values: new object[] { @"(D'you think the end of the world is coming?)
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

Where are you going?", 0 });

            migrationBuilder.InsertData(
                table: "Tracklist",
                columns: new[] { "TracklistId", "ListDateCreated", "TracklistName", "TracklistType", "UniqueKey", "UserId" },
                values: new object[,]
                {
                    { 27, new DateTime(2020, 9, 7, 10, 44, 52, 823, DateTimeKind.Unspecified), "Liked Tracks", "Private", "EW5+HFCitkeFWmyaJk", 8 },
                    { 26, new DateTime(2020, 9, 7, 10, 44, 52, 720, DateTimeKind.Unspecified), "My Discovery Queue", "Private", "7lZuAydF4UqE/yNm0T", 8 },
                    { 20, new DateTime(2020, 8, 27, 19, 1, 41, 490, DateTimeKind.Unspecified), "History", "Private", "x3yfzFrBT0K40sIPJ/", 7 },
                    { 25, new DateTime(2020, 9, 7, 10, 44, 52, 510, DateTimeKind.Unspecified), "History", "Private", "WORVyCl6XUa8RVJDfF", 8 },
                    { 22, new DateTime(2020, 8, 27, 19, 1, 41, 897, DateTimeKind.Unspecified), "Liked Tracks", "Private", "mwJ2vSbfgE6rpDF6sk", 7 },
                    { 21, new DateTime(2020, 8, 27, 19, 1, 41, 810, DateTimeKind.Unspecified), "My Discovery Queue", "Private", "9sf6HCSuGUO6DEBgZe", 7 }
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
                table: "AlbumList",
                keyColumn: "AlbumListId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AlbumList",
                keyColumn: "AlbumListId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Tracklist",
                keyColumn: "TracklistId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Tracklist",
                keyColumn: "TracklistId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Tracklist",
                keyColumn: "TracklistId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Tracklist",
                keyColumn: "TracklistId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Tracklist",
                keyColumn: "TracklistId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Tracklist",
                keyColumn: "TracklistId",
                keyValue: 27);

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
                table: "Post",
                keyColumn: "PostId",
                keyValue: 3,
                column: "IsGlobal",
                value: true);

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "PostId",
                keyValue: 11,
                column: "IsGlobal",
                value: false);

            migrationBuilder.UpdateData(
                table: "Track",
                keyColumn: "TrackId",
                keyValue: 1,
                columns: new[] { "TrackLyrics", "TrackViews" },
                values: new object[] { @"Oh no, don't feel it's right, fall apart, let's not fight
Make up, stay tonight, feel alone, it's alright

It is nothing, it is nothing, it is nothing

Hope lust life what went wrong, see now it's all gone
No-no, don't hold on, feel good what went wrong

It is nothing, it is nothing, it is nothing

Oh no, don't feel it's right, fall apart, let's not fight
Make up, stay tonight, feel alone, it's alright

It is nothing, it is nothing, it is nothing
It is nothing, it is nothing, it is nothing
It is nothing, it is nothing", 10 });

            migrationBuilder.UpdateData(
                table: "Track",
                keyColumn: "TrackId",
                keyValue: 2,
                columns: new[] { "TrackLyrics", "TrackViews" },
                values: new object[] { @"Don't say that you're nice to me alright, you're lying
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
In your heart, in your heart, in your heart, in your heart", 5 });

            migrationBuilder.UpdateData(
                table: "Track",
                keyColumn: "TrackId",
                keyValue: 3,
                columns: new[] { "TrackLyrics", "TrackViews" },
                values: new object[] { @"If love could be the answer then the answer would be you
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
Some things never go away but the feelings gone, the feeling is gone", 0 });

            migrationBuilder.UpdateData(
                table: "Track",
                keyColumn: "TrackId",
                keyValue: 4,
                columns: new[] { "TrackLyrics", "TrackViews" },
                values: new object[] { @"Oh, hear the sound on the tracks and on the run
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
I said what, what the fuck, don't play with my heart, who am I?", 0 });

            migrationBuilder.UpdateData(
                table: "Track",
                keyColumn: "TrackId",
                keyValue: 5,
                columns: new[] { "TrackLyrics", "TrackViews" },
                values: new object[] { @"I sit here waiting as time keeps slipping away
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
My hopes and dreams are crushed and have slipped away", 3 });

            migrationBuilder.UpdateData(
                table: "Track",
                keyColumn: "TrackId",
                keyValue: 6,
                columns: new[] { "TrackLyrics", "TrackViews" },
                values: new object[] { @"Leaving life with a hand to hold
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
And it's acid that makes you lose, gimme acid, gimme acid, gimme acid", 0 });

            migrationBuilder.UpdateData(
                table: "Track",
                keyColumn: "TrackId",
                keyValue: 7,
                columns: new[] { "TrackLyrics", "TrackViews" },
                values: new object[] { @"I'm a little child, smile when you smile
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
I still want you, I still want you, I want you, I still want you", 3 });

            migrationBuilder.UpdateData(
                table: "Track",
                keyColumn: "TrackId",
                keyValue: 8,
                columns: new[] { "TrackLyrics", "TrackViews" },
                values: new object[] { @"Waves wash over everything on the ground
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

Love, love, love, love, love, love, love, love", 0 });

            migrationBuilder.UpdateData(
                table: "Track",
                keyColumn: "TrackId",
                keyValue: 9,
                columns: new[] { "TrackLyrics", "TrackViews" },
                values: new object[] { @"People living in the dark
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
Exploding head, exploding head, exploding head, exploding head", 0 });

            migrationBuilder.UpdateData(
                table: "Track",
                keyColumn: "TrackId",
                keyValue: 22,
                columns: new[] { "TrackLyrics", "TrackViews" },
                values: new object[] { @"I've lived my life to stand in the shadow of your heart
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
I want you back but you're not there", 1 });

            migrationBuilder.UpdateData(
                table: "Track",
                keyColumn: "TrackId",
                keyValue: 23,
                columns: new[] { "TrackLyrics", "TrackViews" },
                values: new object[] { @"The car is on fire, and there's no driver at the wheel
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
I open up my wallet and it's full of blood", 1 });

            migrationBuilder.UpdateData(
                table: "Track",
                keyColumn: "TrackId",
                keyValue: 24,
                columns: new[] { "TrackLyrics", "TrackViews" },
                values: new object[] { @"...Nothing's Alrite in Our Life.../The Dead Flag Blues (Reprise)

Instrumental

The Sad Mafioso...

Instrumental

Drugs in Tokyo/Black Helicopter

They have a large barge with a radio antenna tower on it that they would charge up and discharge
They have a large barge with a radio antenna tower on it that they would charge up and discharge
They have a large barge with a radio antenna tower on it", 0 });

            migrationBuilder.UpdateData(
                table: "Track",
                keyColumn: "TrackId",
                keyValue: 25,
                columns: new[] { "TrackLyrics", "TrackViews" },
                values: new object[] { @"(D'you think the end of the world is coming?)
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

Where are you going?", 0 });

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
