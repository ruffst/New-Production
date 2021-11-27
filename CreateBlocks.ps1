$BlockIds = @(

  'Rohrextruder'
  'Plattenpresse'
  'BasicAssembler'
  'Drahtextruder'
  'Wickelmaschine'
  'Elektro_Assembler'
  'Fertiger'
  'VerbrauchsmaterialAssembler'
  'SurvivalKitLarge'
  'BasicAssembler'

);
$Builder = "CubeBlock"
$Gruppe = "0"

$TextBlock = '
    <ResearchBlock xsi:type="ResearchBlock">                                    <!--XXXXXXXX  Gruppe zzzzz-->
      <Id Type="MyObjectBuilder_yyyyy" Subtype="XXXXXXXX" />
      <UnlockedByGroups>
        <GroupSubtype>zzzzz</GroupSubtype>
      </UnlockedByGroups>
    </ResearchBlock>'

foreach ($Block in $BlockIds)
{
$temp = $TextBlock -replace "XXXXXXXX", $Block
$temp = $temp -replace "yyyyy", $Builder
$temp = $temp -replace "zzzzz", $Gruppe
Write-Host $temp

}
