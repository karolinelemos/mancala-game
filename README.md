# Jogo Mancala em CSharp 
Código do jogo desenvolvido para a disciplina de Inteligência Artificial com o objetivo de aplicar os conhecimentos em busca heurística.


**Objetivo do jogo:** Capturar o maior número de “sementes”.

**Forma de jogar:** O jogo é executado em um tabuleiro, onde cada jogador fica com uma fileira de 6 casas, que é considerado o seu “campo” e mais uma casa onde deposita as “sementes” capturadas.

**Regras do jogo:**

Ao início do jogo, são dispostas 4 “sementes” em cada uma das casas dos jogadores. O primeiro a jogar apanha todas as peças de uma de suas casas e distribui-as uma a uma nas casas adiante, seguindo no sentido anti-horário, incluindo o seu depósito.

• Não se pode tirar “sementes” de casas que só tenham 1 semente enquanto houver casas com 2 ou mais.

• Se a última “semente” do movimento for no depósito o jogador pode fazer uma nova jogada.

• Não se pode mover “sementes” de casas do campo adversário.

• Se a última “semente” do movimento cair em uma casa vazia que seja do seu campo, e a casa oposta do campo do adversário tiver “sementes”, estas vão para o seu depósito.

• Se um jogador, ao realizar um movimento, ficar sem “sementes”, o adversário é obrigado a fazer uma jogada que coloque pelo menos uma semente no seu lado (se tal for possível).

• Se um jogador ao efetuar uma captura, deixar o adversário sem sementes, é obrigado a jogar novamente para colocar pelo menos uma semente no lado deste (se tal for possível).

A partida acaba quando um jogador fica sem sementes e o adversário não consegue fazer uma jogada que passe uma semente para o seu lado, ficando com as sementes existentes o jogador que as tenha do seu lado ou restarem tão poucas sementes sobre o tabuleiro que nenhuma captura seja mais possível.
