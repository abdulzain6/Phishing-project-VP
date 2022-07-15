import os 
os.chdir("Views/Home")
files = os.listdir()
text = """
<tr>
            
            <td>
                {}
            </td>
            <td>
                <a href="~/Home/{}">{} Link</a>
            </td>

        </tr>
"""
for file in files:
    t = text.replace("{}", file)
    print(t)