## Proyecto Domino ##

.

El proyecto Domino está creado de manera tal, que, al ejecutarlo, el usuario pueda implementar una modalidad de Domino a su gusto, a través de la interfaz gráfica.

La solución está compuesta por cuatro proyectos en c# 10, NET Core 6:

- MyDomino
- Domino
- DominoProgram
- Constructor

### C# MyDomino ###


Comenzaremos por hablar del proyecto "MyDomino", el cual contendrá una serie de clases, que implementen el tipo de dominó que todos conocemos, el dominó estándar.

----------


    MyDomino
      > c# TokenDom.cs
      > c# BoardStandard.cs
      > c# PlayerRandom.cs
      > c# TurnsPlayersStandard.cs
      > c# RulesStandard.cs
      > c# ValidMoveStandar.cs
      > c# WinnersStandard.cs
      > c# StartGameStandard.cs
      > c# GameOverStandar.cs
      > ...
       

----------

Estas clases son suficientes para recrear el Dominó estándar, el que todos conocemos. Veamos cómo se componen cada una de estas clases:

### TokenDom ###

    public class TokenDom
    {
        public (int, int) tokenDom;
        public TokenDom((int, int) fichasdom)[...]
        public (int, int) GetToken()[...]
        public int Value()[...] 
        public override string ToString()[...]
        public bool ToEquals(TokenDom other)[...]
    }
    
La variable pública de tipo `(int, int)` `public (int, int) tokenDom` la utilizaremos en es resto de los métodos a continuación.

    public TokenDom((int, int) fichasdom)
    {
        tokenDom = fichasdom;
    }
Esta es una sobrecarga del constructor de la clase, que recibe como parámetro una variable de tipo `(int, int) fichasdom` y la función de este método es asignarle a la variable `tokenDom` el valor del parámetro.

    public (int, int) GetToken()
    {
        return tokenDom;
    }
Este método devuelve un valor de tipo `(int ,int)` y no recibe parámetros. Su función es devolver el valor de la variable pública `tokenDom`.

    public int Value()
    {
        return tokenDom.Item1 + tokenDom.Item2;
    }
Este método devuelve un valor de tipo `int` y no recibe parámetros. Su función es devolver el valor de la ficha, que se calcula en este caso sumando ambos valores de la variable de tipo `(int, int)` `tokenDom`.

    public override string ToString()
    {
        return tokenDom.ToString();
    }
Este método devuelve un valor de tipo `string` y no recibe parámetros. Tiene como objetivo devolver una representación en forma de texto que se acerque a su valor real.

    public bool ToEquals(TokenDom other)
    {
        if (tokenDom.Item1 == other.GetToken().Item1 && tokenDom.Item2 == other.GetToken().Item2) return true;
        else return false;
    }
Este método devuelve un valor de tipo `bool` y recibe como parámetro una variable de tipo `TokenDom`. Su objetivo es comparar dos valores de tipo `TokenDom`, el que recibe como parámetro, y el propio valor `tokenDom` de la clase, y devolver true en caso de que sea iguales, o false en caso de que no lo sean.

### BoardStandard ###


----------
    public class BoardStandar
    {
        public List<TokenDom> registrer;
        public (int, int) actuallyBoard;
        public BoardStandard() [...]
        public void UpdateBoard((TokenDom, int) move) [...]
        public (int, int) GetActuallyBoard() [...]
        public List<TokenDom> GetRegistrer() [...]      
    }

La variable `registrer` de tipo `List<TokenDom>` tiene como objetivo almacenar los elementos de tipo `TokenDom` que se van jugando a medida que transcurre el juego.

La variable `actuallyBoard` de tipo `(int, int)` tiene como objetivo almacenar el valor actual del tablero.

    public BoardStandard ()
    {
        registrer = new List<TokenDom>();
        actuallyBoard = (-1, -1);
    }
Esta sobrecarga del constructor no recibe parámetros. Tiene como objetivo inicializar la variable `registrer` de tipo `List<TokenDom>`, y asignarle a la variable `actuallyBoard` el valor de `(-1, -1)`(que en este caso sería la mesa vacía).

    public void UpdateBoard((TokenDom, int) move)
    {
        int actual;
        registrer.Add(move.Item1);
        if (move.Item1 != null)
        {
        if (move.Item1.tokenDom.Item1 == move.Item2) actual = move.Item1.tokenDom.Item2;
        else actual = move.Item1.tokenDom.Item1;

        if (actuallyBoard.Item1 == move.Item2) actuallyBoard.Item1 = actual;
        else actuallyBoard.Item2 = actual;

        if (move.Item2 == -1) actuallyBoard = move.Item1.tokenDom;
        }
    }

Este método recibe como parámetro la variable `move` de tipo `(TokenDom, int)` y no devuelve valores. Tiene como objetivo actualizar el juego, de manera que, utilizando el método `.Add` de la instancia de `List<TokenDom>` `registrer`, añade a la lista de fichas jugadas, la ultima ficha que se juego, que en este caso sería, `move.Item1`. También actualiza el valor de la variable de tipo `(int, int)` `actuallyBoard`(valor actual de la mesa), utilizando ambos valores de la variable `move`


    public (int, int) GetActuallyBoard()
    {
        return actuallyBoard;
    }
Este método devuelve un valor de tipo `(int, int)` y no recibe parámetros. Tiene como objetivo devolver el valor de la variable `actuallyBoard`.

    public List<TokenDom> GetRegistrer()
    {
        return registrer;
    }
Este método devuelve un valor de tipo `List<TokenDom>` y no recibe parámetros. Tiene como objetivo devolver el valor de la variable `registrer`.

### PlayerRandom ###

    public class PlayerRandom
    {
        public List<TokenDom> tokens;
        public bool winner;
        public string name { get; set; }
        public PlayerRandom(List<TokenDom> hand, string name)[...]
        public (TokenDom, int) Play(BoardStandar board, List<TokenDom> hand, ValidMoveStandard validMove)[...]
        public (TokenDom, int) Euristic(BoardStandard board, List<TokenDom> moves)[...]
        public bool ToEquals(PlayerRandom other)[...]
        public List<TokenDom> GetHand()[...]
        public bool GetWinner()[...]
    }

La variable `tokens` de tipo `List<TokenDom>` tiene como objetivo almacenar las elementos de tipo `TokenDom` que ne este caso serían las fichas de dominó.

La variable `winner` de tipo `bool` tiene como objetivo saber si el jugador ganó la partida anterior.

La variable `name` de tipo `string` tiene como objetivo almacenar un texto, el cual identifique al jugador actual, de los demás jugadores.

    public PlayerRandom(List<TokenDom> tokens, string name)
    {
        this.tokens = tokens;
        this.name = name;
    }

Esta sobrecarga del constructor recibe como parámetro una variable `tokens` de tipo `List<TokenDom>`, y una variable `name` de tipo `string`. Tiene como objetivo asignarle a la variable `tokens` el valor del parámetro `tokens`, y a la variable `name` el valor del parámetro `name`.

    public (TokenDom, int) Play(BoardStandard board, List<TokenDom> hand, ValidMoveStandard validMove)
    {
        List<TokenDom> moves = new List<TokenDom>();
        foreach (TokenDom token in hand)
        {
            if (validMove.ValidMove(board, token)) moves.Add(token);
        }

        return Euristic(board, moves);
    }

Este método devuelve un valor de tipo `(TokenDom, int)` y recibe como parámetro a la variable `board` de tipo `BoardStandard`, a la variable `hand` de tipo `List<TokenDom>`, y a `validMove` de tipo `ValidMove`. Tiene como objetivo devolver todas variables de tipo `TokenDom`(fichas) que pueden jugarse en el momento dado, basándose en el método de la instancia de la clase `ValidMoveStandard` : `validMove.ValidMove(board, token)`.

    public (TokenDom, int) Euristic(BoardStandard board, List<TokenDom> moves)
    {
        if (moves.Count == 0) return (null, -1);
        (TokenDom, int) result;
        Random random = new Random();
        int random_ = random.Next(moves.Count);
        result.Item1 = moves[random_];
        (int, int) board_ = board.GetActuallyBoard();
        if (board_.Item1 == -1 || board_.Item2 == -1) result.Item2 = -1;
        else if (board_.Item1 == moves[random_].tokenDom.Item1) result.Item2 = board_.Item1;
        else if (board_.Item1 == moves[random_].tokenDom.Item2) result.Item2 = board_.Item2;
        else result.Item2 = board_.Item2;

        return result;
    }

Este método devuelve un valor de tipo `(TokenDom, int)`, y recibe los parámetros `board` de tipo `BoardStandard` y `moves` de tipo `List<TokenDom>`. Tiene como objetivo, elegir entre todas las variables de tipo `TokenDom` almacenadas en `moves`(fichas válidas a jugar) una ficha aleatoria, y dependiendo del valor actual del tablero (`board.GetActuallyBoard()`) devolver un valor, de manera que será usado en un futuro por la clase `BoardStandard` para actualizar la variable `actuallyBoard`(que sería en este caso el valor actual de la mesa).

    public bool ToEquals(PlayerRandom other)
    {

        for (int i = 0; i < tokens.Count; i++)
        {
            if (other.GetHand().Contains(tokens[i])) continue;
            else return false;
        }
        return true;
    }

Este método devuelve un valor de tipo `bool`, y recibe como parámetro la variable `other` de tipo `PlayerRandom`. Tiene como objetivo saber si dos jugadores tienen las mismas fichas, en caso de que si, entonces devuelve `true`, en caso de que no, devuelve `false`.

    public List<TokenDom> GetHand()
    {
        return tokens;
    }

Este método devuelve un valor de tipo `List<TokenDom>` y no recibe parámetros. Tiene como objetivo devolver el valor de la variable `tokens`(que en este caso sería las fichas que tiene el jugador).

    public override string ToString()
     {
        return name;
     }

Este método devuelve un valor de tipo `string` y no recibe parámetros. Tiene como objetivo devolver el valor de la variable `name`.

    public bool GetWinner()
    {
        return winner;
    }

Este método devuelve un valor de tipo `bool` y no recibe parámetros. Tiene como objetivo devolver el valor de la variable `winner`, a cual dirá si el jugador ganó el juego anterior.

### TurnsPlayersStandard ###

    public class TurnsPlayersStandard
    {
        public List<bool> players { get; set; }
        public bool directionInv;
        public TurnsPlayers()[...]
        public void NextMove(BoardStandard board)[...]
        public List<bool> GetTurnsPlayers()[...]
        public bool GetDirection()[...]
    }

La variable `players` de tipo `List<bool>` tiene como objetivo almacenar valores `true` o `false`, dependiendo del turno de cada jugador.

La variable `directionInv` tiene como objetivo almacenar un valor `false` en caso de que el sentido de la mesa esté a favor de las manecillas del reloj, y un valor`true` en caso contrario.

    public TurnsPLayersStandard()
    {
        players = new List<bool>();
        directionInv = false;
    }

Esta sobrecarga del constructor no recibe parámetros. Tiene como objetivo inicializar la variable `players`, y darle a la variable `directionInv` su valor por defecto `false`.

    public void NextMove(BoardStandard board)
    {
        for (int i = 0; i < players.Count; i++)
        {
            if (players[i])
            {
                int k = i + 1;
                if (!(k < players.Count)) k = 0;
                players[i] = !players[i];
                players[k] = true;
                break;
            }
        }
    }

Este método no devuelve valores, y recibe como parámetro a la variable `board` de tipo `BoardStandard`. Tiene como objetivo modificar la variable `players`, de manera tal que, recorre todos sus valores hasta encontrar el valor `true`, dado el caso lo convierte en `false`, y le asigna `true` al siguiente elemento(el turno de jugar pasa al siguiente elemento, que en este caso sería el siguiente jugador de la lista).

    public List<bool> GetTurnsPlayers()
    {
        return players;
    }

Este método devuelve un valor de tipo `List<bool>` y no recibe parámetros. Tiene como objetivo devolver el valor de la variable `players`.

    public bool GetDirection()
    {
        return directionInv;
    }

Este método devuelve un valor de tipo `bool` y no recibe parámetros. Tiene como objetivo devolver el valor de la variable `directionInv`.

### RulesStandard ###

    public class RulesStandard
    {
        public List<TokenDom> Tokens(int c)[...]
        public void DistributeTokens(List<TokenDom> tokens, List<PlayerRandom> players, int cant)[...]
        public PlayerRandom[] Winners(BoardStandard board, List<PlayerRandom> players)[...]                
    }

.

    public List<TokenDom> Tokens(int c)
    {
        List<TokenDom> tokens = new List<TokenDom>();
        for (int i = 0; i < c + 1; i++)
            for (int j = i; j < c + 1; j++)
            {
                tokens.Add(new TokenDom((i, j)));
            }

        return tokens;
    }

Este método devuelve un valor de tipo `List<TokenDom>` y recibe como parámetro la variable `c` de tipo `int`. Tiene como objetivo generar todas las fichas del dominó dependiendo de la cantidad que especifique el usuario, que se verá reflejada en el parámetro `c`.

    public void DistributeTokens(List<TokenDom> tokens, List<PlayerRandom> players, int cant)
    {
        if (cant * players.Count > tokens.Count) { throw new Exception("The tokens are not enough"); }

        foreach (var player in players)
        {
            for (int i = 0; i < cant; i++)
            {
                Random random = new Random();
                int random_ = random.Next(tokens.Count);
                player.GetHand().Add(tokens[random_]);
                tokens.RemoveAt(random_);
            }
        }
    }

Este método no devuelve valores y recibe como parámetros la variable `tokens` de tipo `List<TokenDom>`(todas las fichas generadas con el método `.Tokens(...)`), la variable `players` de tipo `List<PlayerRandom>`(cantidad de jugadores) y la variable `cant` de tipo `int`(cantidad de fichas por jugador). Tiene como objetivo distribuirle, a partir de la variable `tokens`, a cada jugador la cantidad que especifica la variable `cant`.


    public PlayerRandom[] Winners(BoardStandard board, List<PlayerRandom> players)
        {
            int value = 0;
            int min_value = int.MaxValue;
            int index = 0;
            IPlayer<TokenDom, (int, int)>[] winners;

            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].GetHand().Count == 0) { winners = new PlayerRandom[1]; winners[0] = players[i]; return winners; }
                
                
                    foreach (var token in players[i].GetHand())
                    {
                        value += token.Value();
                    }
                    if (value < min_value) { min_value = value; index = i; }
                    value = 0;
                

            }
            winners = new PlayerRandom[1]; winners[0] = players[index];
            return winners;
        }

Este método recibe como parámetros a la variable `board` de tipo `BoardStandard` y a la variable `players` de tipo `List<PlayerRandom>`(cantidad de jugadores). Tiene como objetivo devolver en una colección a los jugadores que ganaron el último juego.

### ValidMoveStandard ###

    public classs ValidMoveStandard
    {
        public bool CanMove(BoardStandard board, PlayerRandom player)[...]
        public bool ValidMove(BoardStandard board, TokenDom token)[...]
    }

.

    public bool CanMove(BoardStandard board, PlayerRandmo player)
    {
        foreach (var token in player.GetHand())
        {
            if (ValidMove(board, token)) return true;
        }
        return false;
    }

Este método devuelve un valor de tipo `bool` y recibe como parámetros a la variable `board` de tipo `BoardStandard` y a la variable `player` de tipo `PlayerRandom`. Tiene como objetivo verificar si existe alguna variable de tipo `TokenDom`(ficha), tal que cumpla con el método `.ValidMove(board, token)`. En caso de que si, devuelve `true`, en caso contrario devuelve `false`.

    public bool ValidMove(BoardStandard board, TokenDom token)
    {
        (int, int) actuallyBoard = board.GetActuallyBoard();
        if (actuallyBoard.Item1 == actuallyBoard.Item2 && actuallyBoard.Item1 == -1) return true;
        else if (actuallyBoard.Item1 == token.GetToken().Item1 || actuallyBoard.Item1 == token.GetToken().Item2) return true;
        else if (actuallyBoard.Item2 == token.GetToken().Item1 || actuallyBoard.Item2 == token.GetToken().Item2) return true;
        else return false;
    }

Este método devuelve un valor de tipo `bool` y recibe como parámetros a la variable `board` de tipo `BoardStandard` y a la variable `token` de tipo `TokenDom`. Tiene como objetivo, utilizando los valores de la variable `token`, y de la variable `board`, devolver si la ficha es válida a jugar, en este caso se cumple si al menos uno de los valores de `token` coincide con al menos uno de los valores de `board.GetActuallyBoard()`.

### WinnersStandard ###

    public class WinnersStandard
    {
        public List<PlayerRandom> Winners(BoardStandard board, List<PlayerRandom> players)[...]    
    }

.

    public List<playerRandom> Winners(BoardStandard board, List<PlayerRandom> players)
        {
            int value = 0;
            int min_value = int.MaxValue;
            int index = 0;
            List<IPlayer<TokenDom, (int, int)>> winners = new List<IPlayer<TokenDom, (int, int)>>();

            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].GetHand().Count == 0) { winners.Add(players[i]); return winners; }


                foreach (var token in players[i].GetHand())
                {
                    value += token.Value();
                }
                if (value < min_value) { min_value = value; index = i; }
                value = 0;


            }
            winners.Add(players[index]);
            return winners;
        }

Este método devuelve un valor de tipo `List<PlayerRandom>` y recibe como parámetros a `board` de tipo `BoardStandard` y a `players` de tipo `List<PlayerRandom>`. Tiene como objetivo devolver al jugador que no tenga elementos en el valor devuelto por el método de instancia del tipo `PlayerRandom`(no tenga fichas en la mano), en caso de que no haya un jugador con dichas características, devuelve al jugador que tenga la menor sumatoria de los valores de cada una de sus fichas.

### StartGameStandard ###

    public class StartGameStandard
    {
        public BoardStandard InitializateBoard(BoardStandard board)[...]
        public void PlayerToMove(List<PlayerRandom> players, TurnsPlayersStandard turn)[...]
    }

.

    public BoardStandard InitializateBoard(BoardStandard board)
    {
        board = new BoardStandard();
        return board;
    }

Este método devuelve un valor de tipo `BoardStandard`, y recibe como parámetro una variable de igual tipo. Tiene como objetivo inicializar la variable `board` que tiene como parámetro.

    public void PlayerToMove(List<PlayerRandom> players, TurnsPlayersStandard turn)
    {
        bool win = false;
        for (int i = 0; i < players.Count; i++)
        {
            if (players[i].GetWinner()) { turn.GetTurnsPlayers()[i] = true; win = true; break; };
        }

        if (!win)
        {
            Random random = new Random();
            int random_ = random.Next(turn.GetTurnsPlayers().Count);
            turn.GetTurnsPlayers()[random_] = true;
        }
    }

Este método no devuelve valores y recibe como parámetros a la variable `players` de tipo `List<PlayerRandom>` y a la variable `turn` de tipo `TurnsPlayersStandard`. Tiene como objetivo, dependiendo de los valores de `players`, modifica la variable `turn`, este método es quien decide quien comienza a jugar al dar inicio al juego.


### GameOverStandard ###

    public class GameOverStandard
    {
        public bool GameOver(BoardStandard board, List<PlayerRandom> players, canMove predicate)[...]   
    }

.

    public bool GameOver(BoardStandard board, List<PlayerRandom> players, canMove predicate)
    {
        int count = 0;

        foreach (var player in players)
        {
            if (player.GetHand().Count == 0) return true;
            if (!predicate(board, player)) count++;
        }
        if (count == players.Count) return true;

        return false;
    }

Este método devuelve un valor de tipo `bool` y recibe como parámetros a la variable `board` de tipo `BoardStandard`, a la variable `players` de tipo `List<PlayerRandom>` y a la variable `predicate` de tipo `canMove`(un delegado). Tiene como objetivo determinar cuando el juego termina dependiendo del `predicate` que le pasen como parámetro, en este caso sería el método `.CanMove(...)` de la clase `ValidMoveStandard`, o cuando algún jugador se queda sin elementos en el valor devuelto por el método `.GetHand()` de la clase `PlayerRandom`(se queda sin fichas en la mano).


----------

Con este conjunto de clases ya tenemos suficiente para llevar a cabo el juego de dominó que todos conocemos, nos quedaría construir una interfaz gráfica con la que interactuar con el juego. Teniendo ya la interfaz construida, que pasaría si quisiera implementar un juego de dominó con distintas reglas, tendríamos que modificar toda la interfaz, sin embargo si trabajamos con interfaces solo haría falta crear nuevos métodos que hereden de estas interfaces y cambiar las inicializaciones de las variables con las que trabajaremos en la interfaz gráfica.

### C# Domino ###

Primero creemos un conjunto de interfaces dependiendo de lo que queramos modificar a la hora de crear una variante de dominó, para ello tenemos el proyecto `Domino` que consta de nueve interfaces:

----------


    Domino
      > c# IBoard.cs
      > c# IGameOver.cs
      > c# IPlayer.cs
      > c# IRules.cs
      > c# IStartGame.cs
      > c# IToken.cs
      > c# ITurnsPlayers.cs
      > c# IValidMove.cs
      > c# IWinners.cs
         

----------

### IBoard ###

    public interface IBoard<T, G>
    {
        public void UpdateBoard((T, int) move);
        public G GetActuallyBoard();
        public List<T> GetRegistrer();
    }

*Nota:* Como ya vimos el objetivo que tiene cada uno de estos métodos repasaremos muy brevemente su funcionalidad.

    public void UpdateBoard((T, int) move);

Este método es el encargado de actualizar el valor del tablero, usando la variable `move`.

    
    public G GetActuallyBoard();

Este método devuelve el valor actual de la mesa.

    public List<T> GetRegistrer();
Este método devuelve el registro de fichas que se han jugado.

### IGameOver ###

    namespace Domino
    {
       public delegate bool canMove<T, G>(IBoard<T, G> board, IPlayer<T, G> player);       

       public interface IGameOver
       {
           public bool GameOver(IBoard<T, G> board, List<IPlayer<T, G>> players, canMove<T, G> predicate); 
       }
    }

Junto a esta interfaz agregaremos al delegado público de tipo `bool` `canMove` que recibe como parámetros a la variable `board` de tipo `IBoard<T, G>` y a la variable `player` de tipo `IPlayer<T, G>`.

    public bool GameOver(IBoard<T, G> board, List<IPlayer<T, G>> players, canMove<T, G> predicate);

Este método usa a sus parámetros para determinar si se ha acabado el juego. En el jugo estándar vimos que se acababa cuando uno de los jugadores se quedaba sin fichas en la mano, o cuando ningún jugador podía jugar alguna ficha, también, modificando este método podemos implementar que el juego se termine cuando alguno de los jugadores no tenga fichas para jugar en determinado momento.

### IPlayer ###

    public interface IPlayer<T, G>
    {
        public (T, int) Play(IBoard<T, G> board, List<T> hand, IValidMove<T, G> rules);

        public (T, int) Euristic(IBoard<T, G> board, List<T> moves);

        public bool ToEquals(IPlayer<T, G> other);

        public List<T> GetHand();

        public string ToString();

        public bool GetWinner();
    }

.

    public (T, int) Play(IBoard<T, G> board, List<T> hand, IValidMove<T, G> validMove);

Es el encargado de devolver una ficha que cumpla con `validMove` como predicado.

    public (T, int) Euristic(IBoard<T, G> board, List<T> moves);

Recibe un conjunto de fichas válidas a jugar, y devuelve una de ellas dependiendo de los intereses del jugador. En este caso puede que juegue aleatorio, o que juegue la ficha de mayor valor, o un jugador que alterne entre estas dos modalidades.

    public bool ToEquals(IPlayer<T, G> other);

Devuelve si dos jugadores son iguales con un patrón x de comparación.

    public List<T> GetHand();

Devuelve el conjunto de fichas que contiene el jugador.

    public string ToString();

Devuelve el nombre del jugador.

    public bool GetWinner();

Devuelve si el jugador ganó la ultima partida.

### IRules ###

    public interface IRules
    {
        public List<T> Tokens(int c);

        public void DistributeTokens(List<T> tokens, List<IPlayer<T, G>> players, int cant);

        public IPlayer<T, G>[] Winners(IBoard<T, G> board, List<IPlayer<T, G>> players);
    }

.

    public List<T> Tokens(int c);

Es el encargado de generar todas las fichas.

    public void DistributeTokens(List<T> tokens, List<IPlayer<T, G>> players, int cant);
Es el encargado de repartir las fichas, a partir del valor devuelto por el método `.Tokens`, a cada jugador dependiendo del valor del parámetro `cant`. El método tradicional de repartir las fichas es aleatorio, pero podemos implementarlo de manera tal que ninguno de los jugadores pueda tener en su poder más de dos dobles por ejemeplo.

    public IPlayer<T, G>[] Winners(IBoard<T, G> board, List<IPlayer<T, G>> players);

Es el encargado de devolver quienes son los jugadores ganadores.

### IStartGame ###

    public interface IStartGame<T, G, F>
    {
        public IBoard<T, G> InitializateBoard(IBoard<T, G> board);

        public void PlayerToMove(List<IPlayer<T, G>> players, ITurnsPlayers<T, G, F> turn);
    }

.

    public IBoard<T, G> InitializateBoard(IBoard<T, G> board);

Es el encargado de inicializar la variable `board` que se le pasa como parámetro.

    public void PlayerToMove(List<IPlayer<T, G>> players, ITurnsPlayers<T, G, F> turn);

Es el encargado de decidir cual jugador comienza, en el juego que implementamos comenzaba aleatorio, pero podemos implementar una clase que herede de esta interfaz de manera que el jugador que comience sea el que tenga la mayor sumatoria de valores de las fichas de todos los jugadores, o el que tenga el doble blanco, o el doble nueve.

### IToken ###

    public interface IToken<G>
    {
        public int Value();

        public bool ToEquals(IToken<G> other);

        public G GetToken();
    }

.

    public int Value();

Es el encargado de devolver el valor de la ficha, en el dominó que implementamos, el valor era sumando ambos valores de la ficha, sin embargo podemos implementar una clase de manera que el valor de la ficha sea el menor de sus dos valores, o el mayor, o podemos crear la condición de que si alguno de sus valores es cero, entonces el valor de la ficha será cero.

    public bool ToEquals(IToken<G> other);

Nos dice si dos fichas son iguales, dependiendo de cómo se implemente, se puede considerar que dos fichas son iguales si tienen el mismo valor, o si esas dos fichas tiene un valor en común.

    public G GetToken();

Nos devuelve la información que contiene la ficha.

### ITurnsPlayers ###

    public interface ITurnsPlayers<T, G, F>
    {
        public void NextMove(IBoard<T, G> board);

        public bool GetDirection();

        public F GetTurnsPlayers();
    }

.

    public void NextMove(IBoard<T, G> board);

Es el encargado de modificar el valor devuelto por el método `.GetTurnsPlayers`, de manera que defina quien es el siguiente jugador, en el dominó que implementamos, el jugador siguiente era el que le seguía al último que jugó, sin embargo podemos implementar una clase de manera que el jugador que juegue un doble, tenga la oportunidad de jugar de nuevo, o cuando un jugador se pase, se invierta el orden en que jugaban.

    public bool GetDirection();

Devuelve en que sentido está la mesa.

    public F GetTurnsPlayers();

Devuelve el turno actual de los jugadores.

### IWinners ###

    public interface IWinners<T, G>
    {
        public List<IPlayer<T, G>> Winners(IBoard<T, G> board, List<IPlayer<T, G>> players);
    }

.

    public List<IPlayer<T, G>> Winners(IBoard<T, G> board, List<IPlayer<T, G>> players);
 
Devuelve el jugador o jugadores que hayan ganado la partida, en el dominó que implementamos el(los) ganador(es) eran los que se quedaban sin fichas que jugar, y en caso de acabarse el juego y aún permanecían con fichas, el ganador se decidía por el que tuviera la menor sumatoria de valores de las fichas en la mano.

----------

De esta manera tenemos una serie de interfaces, a partir de la cual podemos crear nuevas clases de manera que, la interfaz gráfica que hayamos creado no necesite ser modificada.

Entonces las clases que ya creamos, heredarían de esta forma:

    public namespace MyDomino
    {
        public class BoardStandard: IBoard<TokenDom, (int, int)>
        {
            ...
            public void UpdateBoard((TokenDom, int) move)[...]
            public (int, int) GetActuallyBoard()[...]
            public List<TokenDom> GetRegistrer()[...]
        }
        
        public class GameOverStandard : IGameOver<TokenDom, (int, int)>
        {
            public bool GameOver(IBoard<TokenDom, (int, int)> board, List<IPlayer<TokenDom, (int, int)>> players, canMove<TokenDom, (int, int)> predicate)[...]        
        }
        
        public class PlayerRandom: IPlayer<TokenDom, (int, int)>
        {
            ...
            public (TokenDom, int) Play(IBoard<TokenDom, (int, int)> board, List<TokenDom> hand, IValidMove<TokenDom, (int, int)> validMove)[...]
            public (TokenDom, int) Euristic(IBoard<TokenDom, (int, int)> board, List<TokenDom> moves)[...]
            public bool ToEquals(IPlayer<TokenDom, (int, int)> other)[...]
            public List<TokenDom> GetHand()[...] 
            public bool GetWinner()[...]
        }
        ...        
    }

Y de igual manera con el resto de las clases que ya habíamos creado, con cada uno de sus métodos teniendo como parámetros a variables de tipo `I...` dependiendo de la interfaz de la que hereda dicha clase.

Solo nos queda inicializar estas clases que heredan de las interfaces según escoja el usuario que va a interactuar con la solución. Para ello contamos con el proyecto : `Constructor`.

### C# Constructor ###


----------

    Constructor
      > c# Board.cs
      > c# GameOver.cs
      > c# Player.cs
      > c# Rules.cs
      > c# StartGame.cs
      > c# Token.cs
      > c# TurnsPlayers.cs
      > c# ValidMove.cs
      > c# Winners.cs

----------

Todas las clases de este proyecto son similares, reciben como parámetro una variable de tipo `string` y devuelven un valor del tipo según la interfaz que implementen. Ejemlpo:

    public class Player
    {
        public IPlayer<TokenDom, (int, int)> player { get; set; }

        public Player(string item)
        {
            switch (item)
            {
                case "PlayerRandom":
                    player = new PlayerRandom(new List<TokenDom>(), "PlayerRandom");
                    break;
                case "PlayerBotaGorda":
                    player = new PlayerBotaGorda(new List<TokenDom>(), "PlayerBotaGorda");
                    break;
                case "PlayerBotaGorda_Random":
                    player = new PlayerBotaGorda_Random(new List<TokenDom>(), "PlayerBotaGorda_Random");
                    break;

                default:
                    player = new PlayerRandom(new List<TokenDom>(), "PlayerRandom");
                    break;
            }
        }        
    }

Tenemos la variable `player` de tipo `IPlayer<TokenDom, (int, int)>` y, dependiendo del parámetro `item` se inicializará esta variable de tipo "`item`".

Ya tenemos un conjunto de interfaces a través de los cuales podemos implementar diferentes variantes de dominó haciendo que estas clases hereden de dichas interfaces, también tenemos un juego de dominó ya implementado, y un conjunto de clases que nos permitirán inicializar las variables dependiendo del tipo que escoja el usuario. Con esto podemos pasar a analizar el proyecto `DominoProgram`, la interfaz gráfica, el motor del programa.

### C# DominoProgram ###

Se trata de un Windows Forms, que respresentará de manera amena lo que ocurre en el juego, y le permitirá al usuario escoger la combinación que más guste de reglas ya creadas. 



    public partial class DominoEngine : Form
    {
        Rules rules_;
        List<TokenDom> tokens;
        Board board_;
        TurnsPlayers turn_;
        StartGame startGame_;
        GameOver gameOver;
        ValidMove validMove;
        Winners winners;
        int totalTokensForPlayers;
        int totalTokens;
        ...
    }

Primero en la clase `DominoEngine : Form` hacemos visible una serie de elementos para el que el resto de la clase los pueda modificar y utilizar al unísono.

    public partial class DominoEngine : Form
    {
        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 6; i < 13; i++)
                TotalTokens.Items.Add(i);

            for (int i = 7; i < 16; i++)
                TotalTokensForPlayer.Items.Add(i);

            lblGameOver.Text = "";
            btnStartGame.Text = "StartGame";

    //------------------------------------------------

            ComboRules.Items.Add("RulesStandar");

            comboPlayers.Items.Add("PlayerRandom");
            ...

            comboNextTurn.Items.Add("TurnsPLayersStandar");
            ...

            comboGameOver.Items.Add("GameOverStandar");
            ...

            comboValidMove.Items.Add("ValidMoveStandard");
            ...

            comboWinners.Items.Add("WinnersStandard");
            ...
        }
    }

Al iniciar la forma añadimos a los `comboBox` todos los elementos que tenemos creados, todas las clases a partir de las cuales el usuario escogerá la combinación de reglas que mejor le convenga.

    public partial class DominoEngine : Form
    {
        ...
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Player player = new Player(comboPlayers.Text);
            players_.players.Add(player.player);
            btnDone.Enabled = true;
            treePlayers.Nodes.Add($"{player.player} {players_.players.Count}");
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = false;
            btnDone.Enabled = false;
        }
        ...
    }

Cuando ejecutamos el programa vemos que en la esquina inferior izquierda tenemos dos botones y un comboBox, el botón "Add" tiene como función añadir a la colección de jugadores que van a participar en el juego, dependiendo de lo que el usuario haya seleccionado en el combobox ya mencionado, y el botón "Done" tiene como objetivo deshabilitar la funcionalidad del botón "Add" en caso de que no se quieran añadir más jugadores. Los jugadores que se eligieron quedan reflejados en la lista ubicada justo encima.

Al ejecutar el programa también podemos percibir otros combobox y otros elementos como por ejemeplo:

    Rules        TotalTokens
    
    NextTurn     TotalTokensForPlayers

    GameOver

    ValidMove

    Winners

A partir de los cuales el usuario eligirá dentro de cada uno de ellos la opción que mas guste.

    private void play_butt_Click(object sender, EventArgs e)
        {
            rules_ = new Rules(ComboRules.Text);
            board_ = new Board("");
            turn_ = new TurnsPlayers(comboNextTurn.Text);            
            for (int i = 0; i < players_.players.Count; i++)
                turn_.turnsPlayers.GetTurnsPlayers().Add(false);
            startGame_ = new StartGame("");
            gameOver = new GameOver(comboGameOver.Text);
            validMove = new ValidMove(comboValidMove.Text);
            winners = new Winners(comboWinners.Text);

            // Total of Tokens for Players
            if (int.TryParse(TotalTokensForPlayer.Text, out totalTokensForPlayers))
            {
                totalTokensForPlayers = int.Parse(TotalTokensForPlayer.Text);
            }
            else throw new Exception("Check the total of tokens for players");

            // Total of Tokens
            if (int.TryParse(TotalTokens.Text, out totalTokens))
            {
                totalTokens = int.Parse(TotalTokens.Text);
                tokens = rules_.rules.Tokens(totalTokens);
            }
            else throw new Exception("Check the total of tokens");

            distributeTokens.Enabled = true;
        }

También podemos ver, cuando inicializamos el programa, justo debajo de `TotalTokensForPlayers`, el botón "InitialitePlayers", el cual tiene como objetivo inicializar todas las opciones que escogió el usuario para crear su variante de dominó, ejemplo, si no seleccionó ninguna, la combinación de estas le generará el juego de dominó estándar, el que todos conocemos.

    private void distributeTokens_Click(object sender, EventArgs e)
        {
            rules_.rules.DistributeTokens(tokens, players_.players, totalTokensForPlayers);
            distributeTokens.Enabled = false;
            PlayersVisualUpdate(players_, turn_);

            btnInitialitePlayersTokens.Enabled = false;
            btnStartGame.Enabled = btnStartGame.Visible = true;
            btnDone.Enabled = false;
            btnAdd.Enabled = false;
        }

Justo debajo del botón "InitialitePlayers" tenemos al botón "DistributeTokens", el cual tiene como objetivo, como bien su nombre especifica, repartir las fichas entre todos los jugadores, además de habilitar un nuevo botón, que sería el botón "StartGame". Veamos que accedemos al método `.DistributeTokens(...)` del tipo `IRules<T, G>` a través de la propiedad `.rules` de la variable `rules_` de tipo `Rules`.

    private void btnStartGame_Click(object sender, EventArgs e)
        {
            //turn = myDom.TurnPlayers(players_.players);


            //startGame = myDom.StartGame();
            board_.board = startGame_.startGame.InitializateBoard(board_.board);
            lblActuallyTable.Text = $"ActuallyTable: {board_.board.GetActuallyBoard()}";
            startGame_.startGame.PlayerToMove(players_.players, turn_.turnsPlayers);

            PlayersVisualUpdate(players_ ,turn_);

            btnNextMove.Visible = true;
            btnNextMove.Enabled = true;
            btnStartGame.Enabled = false;
        }

Este botón tiene como objetivo inicializar el tablero, usando el método `.InitializateBoard(...)` de la propiedad `.startGame`, de tipo `IStartGame`, de la variable `startGame` de tipo `StartGame`. Además de seleccionar el jugador que comenzará a jugar, mediante el método `.PlayerToMove(...)` de la propiedad `.startGame` de la misma variable. Utilizando este botón habilitamos el nuevo botón llamado "NextMove".

    private void bttnNextMove_Click(object sender, EventArgs e)
        {
            if (gameOver.gameOver.GameOver(board_.board, players_.players, (board, player) => validMove.validMove.CanMove(board, player))) GameOver();

            if (validMove.validMove.CanMove(board_.board, player_turn_.player))
            {
                var move = player_turn_.player.Play(board_.board, player_turn_.player.GetHand(), validMove.validMove);
                player_turn_.player.GetHand().Remove(move.Item1);
                board_.board.UpdateBoard(move);
                lstMoves.Items.Add($"{move.Item1} {player_turn_.player}{players_.players.IndexOf(player_turn_.player) + 1} {board_.board.GetActuallyBoard()}");
                lblActuallyTable.Text = board_.board.GetActuallyBoard().ToString();
                turn_.turnsPlayers.NextMove(board_.board);
                PlayersVisualUpdate(players_, turn_);
            }

            else
            {
                var move = player_turn_.player.Play(board_.board, player_turn_.player.GetHand(), validMove.validMove);
                board_.board.UpdateBoard(move);
                lstMoves.Items.Add($"pass  {player_turn_.player} {lblActuallyTable.Text}");
                turn_.turnsPlayers.NextMove(board_.board);
                PlayersVisualUpdate(players_, turn_);
            }
            
            if (gameOver.gameOver.GameOver(board_.board, players_.players, (board, player) => validMove.validMove.CanMove(board, player))) GameOver();
        }

Este botón tiene como objetivo hacer que los jugadores usen sus fichas hasta que se termine el juego. Vemos que primero verificamos si el juego terminó, usando el método `.GameOver(...)` de la propiedad `.gameOver` de tipo `IGameOver<T, G>` de la variable `gameOver` de tipo `GameOver`. Luego verificamos si el jugador tiene fichas válidas a jugar, usando el método `.CanMove(...)` de la propiedad `validMove`, de tipo `IValidMove<T, G>`, de la variable `validMove`, de tipo `ValidMove`. En caso de que si tenga fichas válidas, entonces inicializamos la variable `move`, de tipo `var`, o sea que se especificará el valor que le asignemos, en este caso será el valor devuelto por el método `.Play(...)` de la propiedad `.player` de tipo `IPlayer<T, G>` de la variable `player_turn` de tipo `Player`, luego removemos la ficha que jugó de la mano del jugador, actualizamos el tablero usando el método `.UpdateBoard(...)` de la propiedad `.board`, de tipo `IBoard<T, G>`, de la variable `board_` de tipo `Board`. Luego modificamos la propiedad `turnsPlayers` de tipo `ITurnsPlayers<T, G, F>` de la variable `turns_` de tipo `TurnsPlayers` usando el método `.NextMove(...)` de la misma propiedad, de esta manera le cedemos el turno de jugar, al siguiente jugador. En Caso de que no tenga fichas válidas es un proceso similar. Luego verificamos si el juego terminó usando nuevamente el método `.GameOver(...)`.

    public void PlayersVisualUpdate(PlayerList players, TurnsPlayers turn)
        {
            for (int i = 0; i < players.players.Count; i++)
            {
                treePlayers.Nodes[i] = new TreeNode();
                if (turn != null && turn.turnsPlayers.GetTurnsPlayers()[i] ) { treePlayers.Nodes[i].Text = $"{players.players[i]} {i + 1} ({tok} {players.players[i].GetHand().Count}) playNow"; player_turn_.player = players.players[i]; }
                else treePlayers.Nodes[i].Text = $"{players.players[i]} {i + 1} ({tok} {players.players[i].GetHand().Count})";
                for (int j = 0; j < players.players[i].GetHand().Count; j++)
                {
                    treePlayers.Nodes[i].Nodes.Add(players.players[i].GetHand()[j].ToString());
                }
            }
        }

Este método es el encargado de actualizar la información visual del programa en ejecución.

    public void GameOver()
        {
            btnStartGame.Text = "ResetGame";
            //btnStartGame.Enabled = true;
            btnNextMove.Enabled = false; 
            List<IPlayer<TokenDom, (int, int)>> wineers = winners.winners.Winners(board_.board, players_.players);

            lblGameOver.Text += "TheWinner(s)Is(Are):";
            for (int i = 0; i < wineers.Count; i++)
            {
                lblGameOver.Text += " " + wineers[i].ToString() + (i + 1) ;
            }
        }

Este método es el encargado de imprimir cual(es) jugador(es) gan(ó)(aron) la partida, así como crear las condiciones para el siguiente juego.
   
### Fin. ###

