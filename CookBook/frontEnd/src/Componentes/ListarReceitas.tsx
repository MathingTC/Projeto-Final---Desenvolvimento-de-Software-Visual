import { useEffect, useState } from "react";
import axios from "axios";
import { Receita } from "../Models/Receita";
import "./Css/ListarReceita.css";

function ListarReceitas({onSelecionarReceita, onAdicionarReceita}: {
    onSelecionarReceita: (id: string) => void;
    onAdicionarReceita: () => void;
}){
    const [receitas, setReceitas] = useState<Receita[]>([]);
    const [carregando, setCarregando] = useState(true);
    const [erro, setErro] = useState("");

    useEffect(() =>{
        async function buscarReceitas(){
            try{
                const resposta = await axios.get<Receita[]>(
                    "http://localhost:5093/api/receitas/listar"
                );
                console.log("Receitas recebidas:", resposta.data);
                setReceitas(resposta.data);
                setCarregando(false);

            } catch (erro){
                console.error("Erro ao buscar receitas", erro);
                setErro("Não foi possível carregar as receitas.");
                setCarregando(false);
            }
        }
        buscarReceitas();

    }, []);

    return(
        <section>
            <h2 className="titulo-receita">👨‍🍳 Receitas 👨‍🍳</h2>
            <p className="subtitulo-receitas">
                Escolha a receita que mais combina com seu paladar
                e descubra como prepará-la passo a passo!
            </p>
            {carregando && <p>Carregando receitas...</p>}
            {erro && <p>{erro}</p>}

            {!carregando && !erro && receitas.length === 0 && (
                <p>Nenhuma receita cadastrada! </p>
            )}

            <button
                type="button"
                onClick={onAdicionarReceita}
            >
            Adicionar Receita
            </button>

            <div className="lista-receitas">
                {receitas.map((receita) => (
                    <div key={receita.id} className="card-receita">
                        <h3 className="titulo-card">{receita.nome}</h3>
                        <p className="descricao-card">{receita.descricao}</p>
                        <button className="botao-receita"
                         onClick={() => onSelecionarReceita(receita.id)}>
                            Ver receita
                        </button>
                    </div>
                ))}
            </div>
        </section>
    );

}

export default ListarReceitas;
