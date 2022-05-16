using System.Text;
using Laboratory.Domain.Aggregates;
using Laboratory.Domain.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Laboratory.Application.ProtocolTemplates;

public class ConcreteCubePermanentProtocolTemplate
{
    private static string template => @"\documentclass[a4paper, 12pt]{article}
% \usepackage{amsmath,amscd,amsfonts,amssymb}
\usepackage[T2A]{fontenc}
\usepackage[utf8]{inputenc}
\usepackage{tgtermes}
\usepackage[L7x]{fontenc}
\usepackage[lithuanian]{babel}
% \addto\lithuanian{\inputencoding{latin1}}

\usepackage{multicol}
\usepackage{datetime}
\usepackage[normalem]{ulem}
\usepackage{xcolor}
\usepackage{graphicx} % Allows including images
\usepackage{booktabs} % Allows the use of \toprule, \midrule and \bottomrule in tables
\usepackage{amsthm}
\usepackage{fancyvrb}
\usepackage{float}
% \usepackage[absolute,overlay]{textpos}
\usepackage{multirow}

\usepackage{geometry}
\geometry{
	a4paper,
	total={180mm,257mm},
	left=10mm,
	top=20mm,
}

\usepackage{lastpage}
\usepackage{fancyhdr}
\pagestyle{fancy}
\lhead{\bf Betono kubelinis stipris, LST EN 12390-3. }
\chead{}
\rhead{\bf Prot. ___protocolNumber___; \today} % Bandymų protokolo numerį reikia įrašyti. 
                                    % Jis gali būti generuojamas  automatiškai programos,
									% tačiau tas protokolo numeris negali kartotis, kiekvieno protokolo 
									%  numeris turi būti vienintelis, unikalus.
									% Protokolo numeris paskui turi kartosis protokolo antraštėje
									% T.y. dar vieną kartą kartosis
\lfoot{}
\cfoot{}
\rfoot{\thepage~puslapis~iš~\pageref{LastPage}~puslapių}

% Standartinė puslapio virsaus antraštė. Man nepatinka reikia kartoti \markboth{}{}
% Arba \markright{} kiekvien
% \pagestyle{headings} 




\everydisplay{\color{blue}}
\everymath{\color{blue}}


\newcommand{\hs}{\hskip .1in}
\newcommand{\nin}{\noindent}

\newcommand{\N}{\mathbb{N}}
\newcommand{\Q}{\mathbb{Q}}
\newcommand{\Z}{\mathbb{Z}}
\newcommand{\Pw}{\mathcal{P}}


\newcommand{\leqv}{\leftrightarrow}

\newcommand{\link}[2]{\hyperlink{#1}{\underline{\textcolor{Cerulean}{#2}}}}

\newcommand{\hsp}[1]{\hspace{0.5cm}{(#1)}}

\newcommand{\vs}{\vspace{-0.25cm}}

\newcommand{\Vs}{\vspace{-0.5cm}}

%\newcommand{\VS}{\vspace{-0.75cm}}

% Horizontalus tarpai padidinti
%\newcommand{\hs}{\hspace{0.5cm}}
\newcommand{\Hs}{\hspace{0.75cm}}
\newcommand{\HS}{\hspace{1.0cm}}
\newcommand{\HSS}{\hspace{1.5cm}}
\newcommand{\bc}[1]{\textbf{\uppercase{#1}}}

%\renewcommand{\arraystretch}{2.5}

\usepackage{array}
\usepackage{tabularx}


%--------------------------------------------------------
\begin{document}


\begin{center}
	{\Large Betono kubelinio stiprio nustatymas pagal {\bf LST EN 12390-3}\\
		Bandymų protokolas {\bf \Large \textcolor{blue}{___protocolNumber___}}\\ % Bandymų protokolo numerį reikia įrašyti. Jis gali būti generuojamas  automatiškai programos, tačiau tas protokolo numeris negali kartotis, kiekvieno protokolo numeris turi būti vienintelis, unikalus
	}
\end{center}

{\hspace{2.5cm} {\bf Užsakovas:} \hfill \parbox{12.0cm}{___companyName___, ___companyAddress___, Įmonės kodas, ___companyCode___}} % Reikia čia įrašyti užsakovo rekvizitus  iš programos atitinkamo įvedimo lango

\vspace{0.5cm}

{\hspace{2.5cm} {\bf Vykdytojas:} \hfill \parbox{12.0cm}{___employeeCompanyName___, ___employeeCompanyAddress___, Įmonės kodas, ___employeeCompanyCode___}} % Šitą lauką galima užharkodinti 

\vspace{0.5cm}
\hspace{5.25cm} {\bf Protokolas sudarytas:} { \today } % Lateksas datą generuoja automatiškai \today operatorius nieko iš programos lango įrašyti nereikia 

\hspace{5.25cm} {\bf Bandymai atlikti:} {___testExecutionDate___} % Reikia čia įrašyti bandymų atlikimo datą iš programos įvedimo lango

\hspace{5.25cm} \nin {\bf Bandiniai gauti:} {___testSamplesReceivedDate___} % Reikia čia įrašyti bandinių gavimo datą iš programos įvedimo lango

\vspace{0.5cm}
\hspace{5.25cm} {\bf Bandinius pristatė:} {___testSamplesDeliveredBy___}. % Reikia čia įrašyti kas bandinius pristatė, galima padaryti ir pasirinkimus: Užsakovas / Užsakovo įgaliotas atstovas / Vykdytojas  Į

\hspace{5.25cm} {\bf Bandymus atliko:} {___testExecutedByUserName___}. % Reikia čia įrašyti laboranto vardą ir pavardę

\hspace{5.25cm} {\bf Protokolą sudarė:} {___testExecutedByUserName___}.% Reikia čia įrašyti protokolo sudarytojo vardą ir pavardę

\section{Bandinių imties apibūdinimas}

\hspace{\parindent}{\bf Bandymo tipas pagal LST EN 206-1 8.2.1.2 ir/arba 8.2.1.3 pastraipas:} {___testType___ }
% Čia reikia įrašyti betono gamybos pobūdį: pradinė arba nuolatinė.
% Jeigu gamyba pradinė, tuomet imami trys bandiniai, jeigu nuolatinė tuomet 1 bandinys

{\bf Betono tipas pagal tankį}: {___concreteType___}.% Čia reikia įrašyti betono tipą pagal tankį. dar gali būti kitas pasirinkimas - lengvasis betonas. T.y. iš viso du pasirinkimai: {sunkusis arba normalusi} ir {lengvasis}.

{\bf Gautos arba paimtos imties dydis:} $ ___testSamplesReceivedCount___ $ betoniniai kubeliai. 
	% Čia reikia įrašyti gautų kubelių skaičių
	
	{\bf Bandinių matmenys:} betono kubai { $ (15 \times 15 \times 15) $} cm.
	%  (Arba gali būti ir nestandartinių matmenų. Standartiniai matmenys $ (15 \times 15 \times 15) $, bet gali būti ir $ (10 \times 10 \times 10) $ arba  $ (20 \times 20 \times 20) $ cm; nestandartiniai jeigu ne $ (15 \times 15 \times 15) $ cm, $ (15 \times 15 \times 15) $ cm, arba $ (20 \times 20 \times 20) $ cm).
	
	{\bf Bendras bandinių išvaizdos apibūdinimas bandinių priėmimo metu:} ___testSamplesReceivedComment___  % Šitą tekstą paimti iš programos lauko kuriame jis įdedamas pagal nutylėjimą (t.y. toks kaip tai yra parašyta dabar). Suprantama, kad naudotojas gaali pakeisti tekstą į reikiamą.


\section{Bandymo rezultatai}

%---------------------------------------------------------------
\hspace{\parindent}{\bf Išbandytos imties dydis:} išbandytas $ ___acceptedSampleCount___ $ betoninis kubelis.
% Čia reikia įrašyti išbandytų kubelių skaičių
Po pirminės apžiūros bandymui atrinktas $ ___acceptedSampleCount___ $ kubelis,
% Čia reikia įrašyti atrinktų kubelių skaičių. Pradinės gamybos atveju gali būti 3 bandiniai, o nuolatinės gamybos atveju 1 bandinys.
$ ___rejectedSampleCount___ $ kubelis (kubeliai) išbrokuotas. % Šis įrašas daromas jei yra išbrokuotų kubelių,
% Čia taip pat reikia įrašyti išbrokuotų kubelių skaičių

Bandymo rezultatai surasyti į~\ref{table:bandymu_rezultatai} lentelę.

\section{Skaičiavimo rezultatai}
\begin{enumerate}
	\item \hspace{\parindent}Vidutinio gniuždomojo striprio įvertis $ f_{cm,cube} =  ___averageCrushForce___ $ MPa % Čia reikia įrašyti apskaičiuotą betono vidutinio stiprio įvertį
	      
	\item Vidutinio gniuždomojo striprio įverčio neapibrėžtys:
	      \begin{enumerate}
		      \item Standartinė neapibrėžtis  $ u =  ___standardUncertainty___ $ MPa % Čia reikia įrašyti apskaičiuotą betono vidutinio stiprio įverčio standartinę neapibrėtį
		            
		      \item Išplėstinė neapibrėtis  $ U = k \cdot u = ___extendedUncertainty___ $ MPa, kai išplėstinės neapibrėžties koeficientas $ k = 2$. % Čia reikia įrašyti apskaičiuotą betono vidutinio stiprio įverčio
		            % išplėstinę neapibrėtį kuri skaičiuojasi paprastai U = k * u, imkimer paprastai kad visada k = 2
		            % bet reikia padaryti pasirinkimą programojo ir jo lauką.į
		            
	      \end{enumerate}
	      
	\item Standartinio nuokrypio įvertis $ s = ___standardDeviation___ $ MPa % Čia reikia įrašyti apskaičiuotą betono kubelinio stiprumo vidurkio įvertį
	      
	\item  Charakteristinio stiprio įvertis $ f_{ck,cube} = ___characteristicStrength___ $ MPa % Čia reikia įrašyti apskaičiuotą betono kubelinio stiprumo standartinio nuokrypio įvertį
	      
	\item Artimaiausia mažesnė betono klasė nustatyta pagal kubelinį stiprį $f_{ck,cube}$: $ ___concreteRating___ $
\end{enumerate}
% Čia reikia įrašyti nustatytą betono klasę pvz. kaip čia duota C30/35 iš aibės:
% Sunkiajam arba normaliajam betonui:
%    (*)  pagal cilindrinį stiprį
%         K_cyl = {8 , 12, 16, 20, 25, 30, 35, 40, 45, 50, 55, 60, 70, 80, 90, 100}
%    (**) pagal kubelinį stiprį
%         K_cube = {10, 15, 20, 25, 30, 37, 45, 50, 55, 60, 67, 75, 85, 95, 105, 115}
% Standartinės klasės: K = {C8\10, C12\15, C16\20, C20\25, C25\30, C30\37, C35\45, C40\50, C45\55, C50\60, C55\67, C60\75, C70\85, C80\95, C90\105, C100\115}
%  Čia įraše ""C60\75"" 60 yra K_cyl aibės elementas o 75 yra K_cube aibės elementas. 
% Taigi pagal f_{ck,cube} nustatome klasę t.y. aibės K_cube elementą c_cube
% ir pagal jį įrašome K aibės elementą, kaip čia parodyta C30/35
%  Čia c_cube = min{c ∈ K_cube: c <= f_ck,cube}

% Lengvajam betonui
%    (*)  pagal cilindrinį stiprį
%             LK_cyl = {8, 12, 16, 20, 25, 30, 35, 40, 45, 50, 55, 60, 70, 80}
%    (**) pagal kubelinį stiprį
%             LK_cube = {9, 13, 18, 22, 28, 33, 38, 44, 50, 55, 60, 66, 77, 88}
% Standartinės lengvojo betono klasės: LK = {LC8\9, LC12\13, LC16\18, LC20\22, LC25\28, LC30\33, LC35\38, LC40\44, LC45\50, LC50\55, LC55\60, LC60\66, LC70\77, LC80\88}
%  Čia LC40\44 40 yra LK_cyl aibės elementas o 44 yra LK_cube aibės elementas. 
% Taigi pagal f_{ck,cube} nustatome klasę t.y. aibės LK_cube elementą
% ir pagal jį įrašome K aibės elementą, pvz. LC30/33
% ----------------------------------------------------------------------------------
% Tačiau gali būti ir taip, kad betono klasė gali ir nebūti, Kai f_{ck,cube} < min(K_cube).
% Tada reikia įrašyti, taip: 
%             ""Nustatytas charakteristinis stiupris neatitinka mažiausios betono klasės reikalavimų""

%---------------------------------------------------------------------------------

% 	========================================	

% Į šią lentelę surašomi bandymų duomenys ir skaičiavimų duomenys
% Surašomi: am, bm, F, apskaičiuotas kiekvieno bandinio fcm = F / (am * bm)
% ir pastabos.
\begin{table}[H] % Čia turėtu būti parametras [t] lentelės patalpinimui puslapio viršuje
	% Su overleaf veikia bet su mano vs codu ir mano Tex Life tai neveikia
	% Lentelės iš viso nebraižo kai įvedu [t], arba [h], nežinau kodėl  
	\label{table:bandymu_rezultatai}
	\caption{Bandymų rezultatai}
	\centering
	%\resizebox{\textwidth}{!}{ % Čia reikia atkomentuoti kai lentelė netelpa į puslapį pagal plotį
	\begin{tabular}
		{|m{1.1cm}|            % Band. Nr.
		>{\centering}m{2cm}|   % a
		>{\centering}m{2cm}|   % b
		>{\centering}m{2cm}|   % F
		>{\centering}m{2cm}|   % fck
		>{\raggedright\arraybackslash}m{5cm} |    % Pastabos
		}
		\hline
		\multirow{2}{*}{{Band.}} & \multicolumn{2}{c|}{Skerspjūvio matmenys} & \multirow{1}{*}{Ardančioji} & \multirow{1}{*}{Stipris} & \multirow{3}{*}{Pastabos}   \\
		\cline{2-3}
		                         & $a, $                                     & $b$,                        & jėga $F$,                & gniuždant                 & \\
		Nr.                      & mm                                        & mm                          & kN                       & $f_{c,cube} $, MPa        & \\
		\hline
		1                        & ___testData[0]valueA[0]___ \\ ___testData[0]valueA[1]___ \\ ___testData[0]valueA[2]___ \\ ___testData[0]valueA[3]___ \\ ___testData[0]valueA[4]___ \\ ___testData[0]valueA[5]___ & ___testData[0]valueB[0]___ \\ ___testData[0]valueB[1]___ \\ ___testData[0]valueB[2]___ \\ ___testData[0]valueB[3]___ \\ ___testData[0]valueB[4]___ \\ ___testData[0]valueB[5]___ & ___testData[0]destructivePower___ & ___testData[0]crushingStrength___ & \small{ }  \\
		\hline
		
	\end{tabular}%
	
	%	}
\end{table}

% 	========================================

\end{document}";
    
	public static string GetFile(ConcreteCubeStrengthTest data, Company executingUserCompany, string testExecutedByUserName = "")
	{
		var builder = new StringBuilder(template);
		
		builder.Replace("___protocolNumber___", data.TestProtocolNumber);
		builder.Replace("___companyName___", data.ClientCompany.Name);
		builder.Replace("___companyAddress___", data.ClientCompany.Address);
		builder.Replace("___companyCode___", data.ClientCompany.CompanyCode);
		builder.Replace("___employeeCompanyName___", executingUserCompany.Name);
		builder.Replace("___employeeCompanyAddress___", executingUserCompany.Address);
		builder.Replace("___employeeCompanyCode___", executingUserCompany.CompanyCode);
		builder.Replace("___testExecutionDate___", data.TestExecutionDate.ToString("yyyy/MM/dd"));
		builder.Replace("___testSamplesReceivedDate___", data.TestSamplesReceivedDate.ToString("yyyy/MM/dd"));
		builder.Replace("___testSamplesReceivedCount___", data.TestSamplesReceivedCount.ToString());
		builder.Replace("___testSamplesDeliveredBy___", data.TestSamplesDeliveredBy);
		builder.Replace("___testExecutedByUserName___", testExecutedByUserName);
		builder.Replace("___testType___", data.TestType == TestType.Initial ? "Pradinis" : "Nuolatinis");
		builder.Replace("___concreteType___", data.ConcreteType == ConcreteType.Light ? "Lengvasis" : "Sunkusis arba normalusis");
		builder.Replace("___testSamplesReceivedComment___", data.TestSamplesReceivedComment);
		builder.Replace("___acceptedSampleCount___", data.AcceptedSampleCount.ToString());
		builder.Replace("___rejectedSampleCount___", data.RejectedSampleCount.ToString());
		builder.Replace("___averageCrushForce___", data.AverageCrushForce.ToString("F"));
		builder.Replace("___standardUncertainty___", data.StandardUncertainty.ToString("F"));
		builder.Replace("___extendedUncertainty___", data.ExtendedUncertainty.ToString("F"));
		builder.Replace("___standardDeviation___", data.StandardDeviation.ToString("F"));
		builder.Replace("___characteristicStrength___", data.CharacteristicStrength.ToString("F"));
		builder.Replace("___concreteRating___", data.ConcreteRating);
		for (int i = 0; i < data.TestData.Count; i++)
		{
			var valuesA = data.TestData[i].Dimensions.Where(x => x.Dimension == CubeDimension.A).Select(x => x.Value).ToArray();
			var valuesB = data.TestData[i].Dimensions.Where(x => x.Dimension == CubeDimension.B).Select(x => x.Value).ToArray();

			for (int j = 0; j < valuesA.Length; j++)
			{
				builder.Replace($"___testData[{i}]valueA[{j}]___", valuesA[j].ToString("F"));
				builder.Replace($"___testData[{i}]valueB[{j}]___", valuesB[j].ToString("F"));
			}
			builder.Replace($"___testData[{i}]destructivePower___", data.TestData[i].DestructivePower.ToString("F"));
			builder.Replace($"___testData[{i}]crushingStrength___", data.TestData[i].CrushingStrength.ToString("F"));
		}

		return builder.ToString();
	}
}

