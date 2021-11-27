$BlockIds = @(

  'Meilenstein_Armorlight'
  'Meilenstein_Armorheavy'
  'Meilenstein_ArmorDeko'
  'Meilenstein_Fenster'
  'Meilenstein_Cockpits'
  'Meilenstein_Tools'
  'Meilenstein_Waffen'
  'Meilenstein_Conveyors'
  'Meilenstein_Deko1'
  'Meilenstein_Deko2'
  'Meilenstein_Industrial'
  'Meilenstein_Power'
  'Meilenstein_Lights'
  'Meilenstein_Thruster_Atmo'
  'Meilenstein_Thruster_Hydro'
  'Meilenstein_Thruster_Ionen'
  'Meilenstein_LCDs'
  'Meilenstein_Sound_Blocks'
  'Meilenstein_Gravity'
  'Meilenstein_Mechanic'
  'Meilenstein_Tore'
  'Meilenstein_Räder'
  'Meilenstein_Cargos'
  'Meilenstein_Jumpdrive'
  'Meilenstein_Communication'
  'Meilenstein_Landing'

);
$Builder = "Conveyor"
$Gruppe = "0"

$TextBlock = '
    <ResearchBlock xsi:type="ResearchBlock">                                    <!--XXXXX  zzzzz-->
      <Id Type="MyObjectBuilder_yyyyy" Subtype="XXXXX" />
      <UnlockedByGroups>
        <GroupSubtype>zzzzz</GroupSubtype>
      </UnlockedByGroups>
    </ResearchBlock>'

foreach ($Block in $BlockIds)
{
$temp = $TextBlock -replace "XXXXX", $Block
$temp = $temp -replace "yyyyy", $Builder
$temp = $temp -replace "zzzzz", $Gruppe
Write-Host $temp

}
