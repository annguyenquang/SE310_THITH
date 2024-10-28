import { ApplicationBar } from "../../components/app/ApplicationBar";

export default function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  return (
    <html lang="en">
      <body>
        <ApplicationBar />
        <main>{children}</main>
      </body>
    </html>
  );
}
