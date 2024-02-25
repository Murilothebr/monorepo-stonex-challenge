import Image from "next/image";
import styles from "./page.module.css";
import { HeaderMegaMenu } from '../components/HeaderMenu';
import { BadgeCard } from "../components/ProductCard";

export default function Home() {
  return (
    <div>
    <HeaderMegaMenu />
    <BadgeCard />
    </div>
  );
}
