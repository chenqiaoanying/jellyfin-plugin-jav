using System.Text.Json;
using Jellyfin.Plugin.Jav.Model;

namespace Jellyfin.Plugin.Jav.Test;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        using var client = new HttpClient();
        var request = new HttpRequestMessage();
        request.RequestUri = new Uri("http://192.168.50.149:8080/jav/video/auto/search?keyword=ofje-327");
        var response = client.Send(request);
        var responseContent = response.Content.ReadAsStringAsync().Result;
        var movieJson = "{\"provider\":\"JavBus\",\"detailPageUrl\":\"https://www.javbus.com/OFJE-327\",\"number\":\"OFJE-327\",\"title\":\"OFJE-327 S級美人妻のゲス不倫現場50連発 他人棒の快楽と不貞のベロキス性交8時間\",\"coverUrl\":\"https://www.javbus.com/pics/cover/8e5m_b.jpg\",\"releaseDate\":\"2021-08-13\",\"description\":\"今、アナタの奥さんに起こっていることかもしれない――。快楽マッサージにハマり、旦那の居ぬ間に通いつめたり、同窓会で一夜のアバンチュールを楽しんだり、旦那の目を盗んで隣の男と密会したり、義父と関係を持ったりと奔放な下半身を持つ人妻ばかり。奥田咲、葵つかさ、三上悠亜、天使もえなどエスワン女優たちが濃厚に濃密に演じる、下品でエロく舌を絡ませ絶頂する不倫セックスの数々。\",\"director\":null,\"actors\":[\"奥田咲\",\"星野ナミ\",\"小島みなみ\",\"天使もえ\",\"明日花キララ\",\"あやみ旬果\",\"柳みゆう\",\"安齋らら\",\"ひなたまりん\",\"夢乃あいか\",\"鷲尾めい\",\"三上悠亜\",\"星宮一花\",\"吉高寧々\",\"葵つかさ\",\"琴井しほり\",\"筧ジュン\",\"三上悠亞\",\"安倍亜沙美\"],\"length\":\"PT8H\",\"studio\":\"エスワン ナンバーワンスタイル\",\"label\":\"エスワン ナンバーワンスタイル\",\"series\":\"S1 GIRLS COLLECTION\",\"genres\":[\"高畫質\",\"DMM獨家\",\"キス・接吻\",\"已婚婦女\",\"苗條\",\"巨乳\",\"接吻\",\"4小時以上作品\"],\"samples\":[\"https://www.javbus.com/pics/sample/8e5m_1.jpg\",\"https://www.javbus.com/pics/sample/8e5m_2.jpg\",\"https://www.javbus.com/pics/sample/8e5m_3.jpg\",\"https://www.javbus.com/pics/sample/8e5m_4.jpg\",\"https://www.javbus.com/pics/sample/8e5m_5.jpg\",\"https://www.javbus.com/pics/sample/8e5m_6.jpg\",\"https://www.javbus.com/pics/sample/8e5m_7.jpg\",\"https://www.javbus.com/pics/sample/8e5m_8.jpg\",\"https://www.javbus.com/pics/sample/8e5m_9.jpg\",\"https://www.javbus.com/pics/sample/8e5m_10.jpg\"],\"communityRating\":8.12}";

        var movie = JsonSerializer.Deserialize<Movie>(movieJson);

        Console.WriteLine(movie.Number);

        var actorJson = "{\"provider\":\"Xslist\",\"detailPageUrl\":\"https://xslist.org/zh/model/139994.html\",\"avatarUrl\":\"https://xslist.org/kojav/model2/139000/139994.jpg\",\"name\":\"石川澪\",\"aliases\":[],\"galleries\":[\"https://xslist.org/kojav/model2/139000/139994.jpg\",\"https://m1.xslist.org/gallery/139000/139994/1645769464.jpg\",\"https://m1.xslist.org/gallery/139000/139994/1639540402.jpg\",\"https://m1.xslist.org/gallery/139000/139994/1635484385.jpg\",\"https://m1.xslist.org/gallery/139000/139994/1633398613.jpg\",\"https://m1.xslist.org/gallery/139000/139994/1666402613.jpg\",\"https://m1.xslist.org/gallery/139000/139994/1666400418.jpg\",\"https://m1.xslist.org/gallery/139000/139994/1666400216.jpg\",\"https://m1.xslist.org/gallery/139000/139994/1666399613.jpg\",\"https://m1.xslist.org/gallery/139000/139994/1664510270.jpg\",\"https://m1.xslist.org/gallery/139000/139994/1659593969.jpg\",\"https://m1.xslist.org/gallery/139000/139994/1659583907.jpg\",\"https://m1.xslist.org/gallery/139000/139994/1657083541.jpg\",\"https://m1.xslist.org/gallery/139000/139994/1656990642.jpg\",\"https://m1.xslist.org/gallery/139000/139994/1656985245.jpg\",\"https://m1.xslist.org/gallery/139000/139994/1654656384.jpg\",\"https://xslist.org/zh/gallery/139994\"],\"birthday\":\"2002-03-29\",\"bloodType\":\"n/a\",\"cupSize\":\"C\",\"debutDate\":\"2021-09-01\",\"height\":158,\"measurements\":\"B82 / W58 / H86\",\"nationality\":\"日本\",\"biography\":\"暂无关于石川澪(Mio Ishikawa/20岁)的介绍。\",\"movieList\":[{\"number\":\"MBDD-2076\",\"title\":\"澪のカーニバル/石川澪\",\"releaseDate\":\"2022-10-13\"},{\"number\":\"MIDV-207\",\"title\":\"デビュー1周年だよん コスプレ4本番10発顔射スペシャル！！ 石川澪\",\"releaseDate\":\"2022-10-03\"},{\"number\":\"MIDV-162\",\"title\":\"童貞君チ○ポを優しくイジくりすぎて初パコ暴発パニック めちゃカワ神対応で筆おろしドキュメント！ 石川澪\",\"releaseDate\":\"2022-08-01\"},{\"number\":\"MIDV-140\",\"title\":\"ヤリまくり一泊二日の温泉旅行で本能のままオマ○コ性交 石川澪\",\"releaseDate\":\"2022-07-04\"},{\"number\":\"OAE-218\",\"title\":\"ALL NUDE 石川澪\",\"releaseDate\":\"2022-06-27\"},{\"number\":\"MIDV-119\",\"title\":\"激イキ172回！膣痙攣3532回！本気汁13909cc！ 禁欲焦らしオーガズム大覚醒スペシャル！！～26日間溜め込んだ性欲が爆発した一日～ 石川澪\",\"releaseDate\":\"2022-06-06\"},{\"number\":\"MIDV-098\",\"title\":\"\\\"Because I Love Sucking Cock, That's All I Think About!\\\" Hot Young Chick Who Loves Sucking Cock Makes This Older Guy's Balls Explode With Sucking And Anal Rimming From This Girl In A Uniform Who Can't Suck Enough. Mio Ishikawa.\",\"releaseDate\":\"2022-05-02\"},{\"number\":\"MIDV-077\",\"title\":\"We Discovered This Diamond-In-The-Rough Beautiful Girl Who Seems \\\"Normal\\\" But Has Super Star Potential, And Here She Is, Taking Her Thrilling, Nervous First Challenge A Hospitable Soapland Mio Ishikawa\",\"releaseDate\":\"2022-04-04\"},{\"number\":\"MIDV-057\",\"title\":\"Even If YOu Ejaculate Once, This Rejuvenating Massage Parlor Will Continue Looking After You And Jerking You Off - Mio Ishikawa\",\"releaseDate\":\"2022-02-28\"},{\"number\":\"MIDV-041\",\"title\":\"My Younger Sister Is Good At Tempting Men With Panty Shots - Mio Ishikawa\",\"releaseDate\":\"2022-01-31\"},{\"number\":\"MIDV-024\",\"title\":\"Eros Awakening 4 Times In A Row, Cumming 161 Times, Uterus Spasms 189 Times, Man Juice 2448cc, Mio Ishikawa\",\"releaseDate\":\"2022-01-03\"},{\"number\":\"MIDV-011\",\"title\":\"Your First Sleepover Date You'll Hold Hands, Kiss, Laugh, And Then, You'll Forget All About The Time As You Intertwine Your Bodies In Deep And Rich Sex Mio Ishikawa\",\"releaseDate\":\"2021-12-06\"},{\"number\":\"MIDE-989\",\"title\":\"Of Course It's Embarrassing, But It's Time For Some Hardcore Sex Training! Nothing But First Experiences! A Sensuality-Awakening 3-Fuck Special Mio Ishikawa\",\"releaseDate\":\"2021-11-01\"},{\"number\":\"MIDE-974\",\"title\":\"Newcomer, Star Gemstone Found In A 'Normal' Exclusive 19 Year Old Porn Debut, Mio Ishikawa\",\"releaseDate\":\"2021-10-04\"},{\"number\":\"MDVR-195\",\"title\":\"[VR] Mio Ishikawa First-time VR! She's So Cute! But She's So Easy To Give Orgasms To! \\\"For Her First VR She Wants You To Fuck Her Hard And Make Her Orgasm Like Crazy! 2 Sex Scenes With Non-stop Climaxing In This Special With High Quality Video!\",\"releaseDate\":null}]}";

        var actor = JsonSerializer.Deserialize<Actor>(actorJson);

        Console.WriteLine(actor.Name);
    }
}