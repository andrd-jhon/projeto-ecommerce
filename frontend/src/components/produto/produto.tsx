import Link from "next/link";
import Image from "next/image";
import {useEffect, useState} from "react";

interface Produto {
  id: number
  nome: string
  preco: number
  categoriaId: number
  ativo: boolean
}

const Produto = () => {

    const [produtos, setProdutos] = useState<Produto[]>([])

    useEffect(() => {
    async function carregarProdutos() {
      const response = await fetch("https://localhost:7083/Produtos")

      if (!response.ok) {
        throw new Error("Erro ao carregar produtos.")
      }

      const data: Produto[] = await response.json()

      setProdutos(data)
    }

    carregarProdutos()
  }, [])

    return (
        <>
        <h1>HOME PAGE</h1>
        <ul>
            {produtos.map((produto) => (
            <li key={produto.id}>
                <Link href={`/produto/${produto.id}`}>
                <h2>{produto.nome}</h2>

                <Image
                    src="/download.png"
                    alt={produto.nome}
                    width={150}
                    height={150}
                />

                <span>R$ {produto.preco}</span>
                </Link>
            </li>
            ))}
        </ul>
        </>
    );
};

export default Produto;
