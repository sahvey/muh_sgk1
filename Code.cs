for (int i = 1; i < 5; i++)
            {
                listBox1.Items.Add(doc.DocumentNode.SelectSingleNode($"//*[@id='contentContainer']/div/table/tr/td/table/tr[2]/td[2]/table/tr[{i}]/td[3]").InnerText.Replace("&Uuml;","Ü").Replace("&Ccedil;","Ç").Replace("&Ouml;","Ö"));
            }
