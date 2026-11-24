import { useEffect, useState } from "react";
import axios from "axios";
import { Receita } from "../Models/Receita";

function ListarReceitas(){
    const [receitas, setReceitas] = useState<Receita[]>([]);
    const [receitaSelecionada, setReceitaSelecionada] = useState<Receita | null>(null);
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
            <h2>Receitas</h2>
            {carregando && <p>Carregando receitas...</p>}
            {erro && <p>{erro}</p>}

            {!carregando && !erro && receitas.length === 0 && (
                <p>Nnehuma receita cadastrada! </p>
            )}

            <div className="lista-receitas">
                {receitas.map((receita) => (
                    <div key={receita.id} className="card-receita">
                        <h3>{receita.nome}</h3>
                        <p>{receita.descricao}</p>
                        <button onClick={() => setReceitaSelecionada(receita)}>
                            Ver receita
                        </button>
                    </div>
                ))}
            </div>
        </section>
    );

}

export default ListarReceitas;