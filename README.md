Journal de bord du développement de Two Simension
Session de travail 1 – Début du projet et changement de dimension

Au lancement du projet, l’objectif principal était de concevoir un système de changement de dimension permettant au joueur de basculer entre deux réalités distinctes.
Initialement, je souhaitais mettre en place un système complexe reposant sur des variables globales accessibles depuis plusieurs scripts. Cependant, mes connaissances en Unity étant encore limitées, j’ai opté pour une méthode plus simple et robuste.

J’ai donc créé deux objets enfants du joueur : TriggerBlue et TriggerRed, chacun doté d’une Box Collider et d’un tag correspondant à sa couleur.
Lorsqu’on appuie sur E, le collider actif se place autour du joueur tandis que l’autre est déplacé sous la carte, environ cinq mètres plus bas.
En réappuyant sur E, les colliders échangent leurs positions.
Ce système permet d’alterner entre deux “dimensions” sans désactiver de composants, évitant ainsi les bugs rencontrés dans les premières phases du projet.
C’est ce mécanisme qui détermine la manière dont le joueur interagit avec les ennemis bleus ou rouges.

Session de travail 2 – Caméra, level design et système de spawn

Une fois le système de dimension en place, j’ai retravaillé la caméra et le level design pour donner l’impression que le joueur observe le jeu à travers un écran d’ordinateur.
La caméra est désormais fixe, ce qui renforce la lisibilité et la mise en scène.

J’ai ensuite ajouté des spawners sur les bords du rectangle de jeu. Ces spawners font apparaître des ennemis de manière aléatoire sur des lignes définies.
J’ai ajusté leurs vitesses, leurs positions et leurs fréquences d’apparition afin d’équilibrer le rythme du jeu.
Les ennemis se déplacent en ligne droite d’un bord à l’autre, créant ainsi une dynamique simple, claire et lisible.

Session de travail 3 – Gestion du score et feedbacks sonores

J’ai ensuite intégré un système de score :

Toucher un ennemi de la même couleur que le joueur ajoute un point.

Toucher un ennemi de couleur opposée en retire un.

Pour renforcer la sensation de feedback, j’ai ajouté des effets sonores contextuels : un son différent pour chaque type d’interaction (gain, perte, défaite).
J’ai également intégré plusieurs musiques d’ambiance afin de rendre le jeu plus immersif et de rythmer les parties.

Session de travail 4 – Ajout du bonus de vitesse

Pour ajouter du dynamisme, j’ai intégré un bonus de vitesse, représenté par un carré violet.
Ce bonus apparaît de manière aléatoire sur la carte grâce à un spawner dédié et disparaît après quelques secondes.
Lorsqu’un joueur le ramasse, sa vitesse augmente pendant cinq secondes, avant de revenir à la normale.
Ce système permet de varier le rythme et d’encourager la prise de risque.

Session de travail 5 – Menu principal et structure du jeu

J’ai ensuite créé un menu principal interactif, conçu comme un niveau jouable.
Plutôt que d’utiliser un menu classique à boutons, le joueur peut se déplacer directement dans la scène, où les touches et les options principales (jouer, quitter, etc.) sont affichées dans l’environnement.
Cela permet une transition fluide entre le menu et le jeu, en conservant la cohérence visuelle et ludique du projet.

J’ai également ajouté plusieurs canvas pour gérer les transitions entre états (victoire, défaite, pause) et commencé à travailler sur la transition entre les niveaux, en prévoyant de dupliquer la première carte pour créer la suivante.

Session de travail 6 – Ajout des “Killers”

Pour renforcer la difficulté et introduire une notion de vie, j’ai ajouté un nouveau type d’ennemi : les Killers.
Ils ressemblent aux ennemis normaux, mais sont identifiables par une croix noire sur leur surface.
Lorsqu’un joueur entre en contact avec un Killer, il perd une vie. Le joueur dispose de trois vies, et lorsqu’il les perd toutes, la partie se termine et doit être recommencée depuis le début.
Cette mécanique introduit une véritable condition de défaite, indépendante du score.

Session de travail 7 – Zones environnementales : heal et dégâts

J’ai ensuite ajouté des zones environnementales ayant des effets temporaires.
Elles apparaissent de manière aléatoire sur la carte, après un avertissement visuel (“warning”) affiché 1,5 seconde avant leur apparition.
Chaque zone possède une apparence spécifique :

Les zones rouges infligent des dégâts.

Les zones vertes restaurent de la vie.

Ces éléments ajoutent un facteur stratégique, car le joueur doit se positionner correctement et anticiper les zones à venir.

Session de travail 8 – Ajout des antivirus

J’ai introduit les antivirus, de nouveaux objets représentés par des carrés bleu clair.
Ils apparaissent aléatoirement sur la carte, mais plus rarement que les bonus de vitesse.
Lorsqu’un joueur entre en contact avec un antivirus, une zone de protection temporaire apparaît autour de lui.
Pendant environ cinq secondes, cette zone permet de neutraliser les virus et de manger librement tous les ennemis rouges ou bleus sans subir de pénalité.
Cette mécanique donne au joueur un court moment de sécurité pour traverser les zones les plus dangereuses du niveau.

Session de travail 9 – Équilibrage, progression et finition

Dans cette dernière phase, j’ai travaillé sur l’équilibrage global du jeu afin que la difficulté augmente progressivement d’un niveau à l’autre :

Niveau 1 : présence d’ennemis normaux et de Killers, introduction des mécaniques de base.

Niveau 2 : apparition des antivirus et des zones environnementales (soin et dégâts).

Niveau 3 : réintroduction de tous les éléments précédents, avec davantage de virus et de zones de danger pour intensifier la difficulté.

J’ai également corrigé plusieurs canvas, ajouté des boutons interactifs dans mes menus, et retravaillé les matériaux et textures pour améliorer la lisibilité et l’identité visuelle du jeu.
Ces ajustements marquent la consolidation du projet et la mise en place d’une version stable et cohérente de Two Simension.

Bilan du développement

Pendant ce projet, j’ai appris énormément de choses, aussi bien sur Unity que sur la structure d’un jeu complet.
J’ai également utilisé un logiciel appelé Bezi, qui m’a beaucoup aidé à comprendre certains aspects du code lorsque je bloquais sur des problèmes techniques car c'est un logiciel que l'on relis a sont projet unity et qui peut donc fouiller dans le code pour comprendre des probeleme que j'aurais mis des jours a trouvé sans aide exterieur.

Avec le recul, je me rends compte que certaines parties de mon code, notamment celles du début du projet, auraient pu être plus optimisées.
Grâce à mes connaissances actuelles, je saurais aujourd’hui améliorer leur architecture et éviter certaines répétitions.

Malgré ces limites, je suis très content du résultat final.
