import Image from "next/image";
import styles from "./page.module.css";
import { HeaderMegaMenu } from '../components/HeaderMenu';
import { BadgeCardTopListing } from "../components/ProductCard";
import { Card, Text, Group, Badge, Button, ActionIcon } from '@mantine/core';

export default function Home() {
  return (
    <div>
    <HeaderMegaMenu />

    <Text size="lg" style={{ marginBottom: '20px', textAlign: 'center', fontWeight: '100px', fontSize: '45px'}}>Top Products</Text>

    <BadgeCardTopListing />
    </div>
  );
}
