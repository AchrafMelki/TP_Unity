# TP_Unity

faire une pull request sur /dev : 

récupérer les maj sur dépot distant : git fetch -p 

git log pour voir vous êtes à jour avec /dev 
-> si oui vous pouvez faire la pull request
-> si non : 
faire son commit de sa nouvelle feature et récupérer son sha (numéro) 
git reset --hard origin/dev sur sa branch locale
git cherry-pick le numéro sha 
git push 
