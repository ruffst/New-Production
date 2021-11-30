$BlockIds = @(




  'LargeGridBeamBlock'
  'LargeGridBeamBlockSlope'
  'LargeGridBeamBlockRound'
  'LargeGridBeamBlockSlope2x1Base'
  'LargeGridBeamBlockSlope2x1Tip'
  'LargeGridBeamBlockHalf'
  'LargeGridBeamBlockHalfSlope'
  'LargeGridBeamBlockEnd'
  'LargeGridBeamBlockJunction'
  'LargeGridBeamBlockTJunction'
  'SmallGridBeamBlock'
  'SmallGridBeamBlockSlope'
  'SmallGridBeamBlockRound'
  'SmallGridBeamBlockSlope2x1Base'
  'SmallGridBeamBlockSlope2x1Tip'
  'SmallGridBeamBlockHalf'
  'SmallGridBeamBlockHalfSlope'
  'SmallGridBeamBlockEnd'
  'SmallGridBeamBlockJunction'
  'SmallGridBeamBlockTJunction'


);
$Builder = "CubeBlock"
$Freigeschaltet = "Meilenstein_ArmorDeko"

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
$temp = $temp -replace "zzzzz", $Freigeschaltet
Write-Host $temp

}
